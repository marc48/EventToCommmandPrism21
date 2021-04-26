using MyEventComPrism21.Models;
using MyEventComPrism21.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyEventComPrism21.ViewModels
{
    public class SimpleExamplePageViewModel : BindableBase
    {
        private readonly IPageDialogService _pageDialogService;
        public DelegateCommand SelectedDeveloperCommand { get; private set; }
        public ObservableCollection<Developer> Developers { get; set; }

        public SimpleExamplePageViewModel(IPageDialogService pageDialogService, IDataProvider dataProvider)
        {
            _pageDialogService = pageDialogService;

            SelectedDeveloperCommand = new DelegateCommand(SelectedDeveloper);

            // Insert test data into collection of Developers
            Developers = new ObservableCollection<Developer>();
            foreach (var person in dataProvider.GetAllData())
            {
                Developers.Add(person);
            }
        }

        private async void SelectedDeveloper()
        {
            await _pageDialogService.DisplayAlertAsync("Info.", "Some developer is selected.", "Ok");
        }
    }
}

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
    public class EventArgsConverterExamplePageViewModel : BindableBase
    {
        private readonly IPageDialogService _pageDialogService;
        public ObservableCollection<Developer> Developers { get; set; }
        public DelegateCommand<Developer> SelectedDeveloperCommand { get; private set; }

        public EventArgsConverterExamplePageViewModel(IPageDialogService pageDialogService,
            IDataProvider dataProvider)
        {
            _pageDialogService = pageDialogService;

            SelectedDeveloperCommand = new DelegateCommand<Developer>(SelectedDeveloper);

            // Insert test data into collection of Developers
            Developers = new ObservableCollection<Developer>();
            foreach (var developer in dataProvider.GetAllData())
            {
                Developers.Add(developer);
            }
        }

        private async void SelectedDeveloper(Developer developer)
        {
            await _pageDialogService.DisplayAlertAsync("Info", $"{developer.FullName} from {developer.Country} is selected.", "Ok");
        }
    }
}

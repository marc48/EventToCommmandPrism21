using MyEventComPrism21.Models;
using MyEventComPrism21.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace MyEventComPrism21.ViewModels
{
    public class EventArgsConverterExamplePageViewModel : BindableBase
    {
        private string _heightText;
        public string HeightText
        {
            get { return _heightText; }
            set { SetProperty(ref _heightText, value); }
        }

        private readonly IPageDialogService _pageDialogService;
        public ObservableCollection<Developer> Developers { get; set; }
        public DelegateCommand<Developer> SelectedDeveloperCommand { get; private set; }
        public DelegateCommand<Stackheight> SizeUpdateCommand { get; private set; }

        public EventArgsConverterExamplePageViewModel(IPageDialogService pageDialogService,
            IDataProvider dataProvider)
        {
            _pageDialogService = pageDialogService;

            SelectedDeveloperCommand = new DelegateCommand<Developer>(SelectedDeveloper);
            SizeUpdateCommand = new DelegateCommand<Stackheight>(SizeUpdate);

            // Insert test data into collection of Developers
            Developers = new ObservableCollection<Developer>();
            foreach (var developer in dataProvider.GetAllData())
            {
                Developers.Add(developer);
            }
            
            _heightText = "Status...";
        }

        int anzahl = 0;
        private void SizeUpdate(Stackheight stackheight) 
        {
            //var newSize = (Size)size;
            anzahl += 1;
            if (stackheight != null)
            {
                HeightText = "StackLayout SizeUpdated: " + anzahl + " mal, Height: " + stackheight.Height;
            }
            else
            {
                HeightText = "StackLayout SizeUpdated: " + anzahl + " mal, Fehler height !!!";
            }
        }

        private async void SelectedDeveloper(Developer developer)
        {
            await _pageDialogService.DisplayAlertAsync("Info", $"{developer.FullName} from {developer.Country} is selected.", "Ok");
        }
    }
}

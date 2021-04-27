using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEventComPrism21.ViewModels
{
    public class TestPageViewModel : BindableBase
    {
        private readonly IPageDialogService _pageDialogService;
        public DelegateCommand SizeUpdateCommand { get; set; }
        public DelegateCommand FillText1Command { get; set; }
        public DelegateCommand FillText2Command { get; set; }

        int anzahl = 0;

        private string _statusText;
        public string StatusText
        {
            get { return _statusText; }
            set { SetProperty(ref _statusText, value); }
        }

        private string _stack1Text;
        public string Stack1Text
        {
            get { return _stack1Text; }
            set { SetProperty(ref _stack1Text, value); }
        }

        private string _stack2Text;
        public string Stack2Text
        {
            get { return _stack2Text; }
            set { SetProperty(ref _stack2Text, value); }
        }

        string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public TestPageViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
            _title = "Testseite";
            SizeUpdateCommand = new DelegateCommand(SizeUpdate);
            FillText1Command = new DelegateCommand(FillText1);
            FillText2Command = new DelegateCommand(FillText2);

            _statusText = "Status ...";
            _stack1Text = "leer...";
            _stack2Text = "leer...";

        }

        private void FillText2()
        {
            Stack2Text += "Neuer Text wird hier geschrieben. ";
        }

        private void FillText1()
        {
            Stack1Text += "Neuer Text wird hier geschrieben. ";
        }

        private void SizeUpdate()
        {
            anzahl += 1;
            StatusText = "Stack2 SizeChanged: " + anzahl + " mal, Height Stack2 = ???";
        }
    }
}

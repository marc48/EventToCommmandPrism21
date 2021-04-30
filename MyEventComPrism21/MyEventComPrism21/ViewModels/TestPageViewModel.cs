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
        public DelegateCommand<object> SizeChangedCommand { get; set; }
        public DelegateCommand FillText1Command { get; set; }
        public DelegateCommand FillText2Command { get; set; }
        public DelegateCommand AugmentHight1Command { get; set; }
        public DelegateCommand HeightReqClearCommand { get; set; }

        int anzahl = 0;

        private string _wlLabelText;
        public string WlLabelText
        {
            get { return _wlLabelText; }
            set { SetProperty(ref _wlLabelText, value); }
        }

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
        private double _stack1Req;
        public double Stack1Req
        {
            get { return _stack1Req; }
            set { SetProperty(ref _stack1Req, value); }
        }
        private double _stack2Req;
        public double Stack2Req
        {
            get { return _stack2Req; }
            set { SetProperty(ref _stack2Req, value); }
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
            SizeChangedCommand = new DelegateCommand<object>(SizeUpdate);
            FillText1Command = new DelegateCommand(FillText1);
            FillText2Command = new DelegateCommand(FillText2);
            AugmentHight1Command = new DelegateCommand(Stack1Heigher);
            HeightReqClearCommand = new DelegateCommand(ClearRequests);
            
            _statusText = "Status ...";
            _stack1Text = "Stack1...";
            _stack2Text = "Stack2...";

            _stack1Req = -1;
            _stack2Req = -1;

            _wlLabelText = "wort";
        }

        private void ClearRequests()
        {
            Stack2Text = "geleert...";
            // -1 fkt. nur, wenn Label geleert!
            Stack1Req = -1;
            Stack2Req = -1;
        }

        private void Stack1Heigher()
        {
            // Ausgangshöhe = 59
            if (Stack1Req > 58)
            {
                // um 10 erhöhen
                Stack1Req += 10;
            }
            else
            {
                Stack1Req = 59;
            }
            
        }

        private void SizeUpdate(object obj)
        {
            anzahl += 1;
            StatusText = "Stack2 SizeChanged: " + anzahl + " mal, Height Stack2: " + obj.ToString();
            // Stack 1 an 2 anpassen
            Stack1Req = (double)obj;
        }

        private void FillText2()
        {
            Stack2Text += "Neuer Text wird hier geschrieben. ";
        }

        private void FillText1()
        {
            Stack1Text += "Neuer Text wird hier geschrieben. ";
        }
    }
}

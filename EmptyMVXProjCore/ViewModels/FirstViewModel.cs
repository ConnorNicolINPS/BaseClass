using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using EmptyMVXProjCore.Model;

namespace EmptyMVXProjCore.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private ICommand getNamesCommand;
        private ICommand printNamesCommamd;
        private ObservableCollection<Person> listOfNames;

        public FirstViewModel()
        {
            this.ListOfNames = new ObservableCollection<string>();
        }

        public ICommand GetNamesCommand
        {
            get { return this.getNamesCommand ?? (this.getNamesCommand = new MvxCommand(GetNamesAction)); }
        }

        public ICommand PrintNamesCommamd
        {
            get { return this.printNamesCommamd ?? (this.printNamesCommamd = new MvxCommand(PrintNamesAction)); }
        }

        public ObservableCollection<Person> ListOfNames
        {
            get { return this.listOfNames; }
            set { this.SetProperty(ref this.listOfNames, value); }
        }


        private void GetNamesAction()
        {
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Ronald", "Weasly"));
            ListOfNames.Add(new Person("Miss", "Hermiony", "Granger"));
            ListOfNames.Add(new Person("Miss", "Ginny", "Weasly"));
            ListOfNames.Add(new Person("Mr", "Fred", "Weasly"));
            ListOfNames.Add(new Person("Mr", "George", "Weasly"));
            ListOfNames.Add(new Person("Mr", "Percy", "Weasly"));
            ListOfNames.Add(new Person("Mr", "Charles", "Weasly"));
            ListOfNames.Add(new Person("Mr", "James", "Potter"));
            ListOfNames.Add(new Person("Mrs", "Lilly", "Potter"));
            ListOfNames.Add(new Person("Mr", "Sirious", "Black"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));
            ListOfNames.Add(new Person("Mr", "Harry", "Potter"));

        }

        private void PrintNamesAction()
        {
            throw new NotImplementedException();
        }
    }
}

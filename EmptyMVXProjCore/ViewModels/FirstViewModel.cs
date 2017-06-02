using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using EmptyMVXProjCore.Model;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EmptyMVXProjCore.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private ICommand getNamesCommand;
        private ObservableCollection<Person> listOfNames;
        private bool getNameEnabled;

        public FirstViewModel()
        {
            this.ListOfNames = new ObservableCollection<Person>();
            GetNameEnabled = true;
        }

        public ICommand GetNamesCommand
        {
            get { return this.getNamesCommand ?? (this.getNamesCommand = new MvxCommand(GetNamesAction)); }
        }

        public ObservableCollection<Person> ListOfNames
        {
            get { return this.listOfNames; }
            set { this.SetProperty(ref this.listOfNames, value); }
        }

        public bool GetNameEnabled
        {
            get { return this.getNameEnabled; }
            set { this.SetProperty(ref this.getNameEnabled, value) ; }
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
            ListOfNames.Add(new Person("Prof", "Remus", "Lupin"));
            ListOfNames.Add(new Person("Mrs", "Nymphadora", "Lupin"));
            ListOfNames.Add(new Person("Lord", "Voldemort", "Evilson"));
            ListOfNames.Add(new Person("Mr", "Tom", "Riddle"));
            ListOfNames.Add(new Person("Prof", "Serverus", "Snape"));
            ListOfNames.Add(new Person("Mr", "Peter", "Perttigrew"));
            ListOfNames.Add(new Person("Mrs", "Bleatrix", "Lestrange"));
            ListOfNames.Add(new Person("Mr", "Draco", "Malfoy"));
            ListOfNames.Add(new Person("Mr", "Lucius", "Malfoy"));
            ListOfNames.Add(new Person("Mr", "Narcissa", "Malfoy"));
            ListOfNames.Add(new Person("Prof", "Albus", "Dumbledore"));
            ListOfNames.Add(new Person("Prof", "Minerva", "McGonagall"));
            ListOfNames.Add(new Person("Miss", "Luna", "Lovegoode"));
            ListOfNames.Add(new Person("Mr", "Nevil", "Longbottom"));
            ListOfNames.Add(new Person("Mr", "Alastor", "Moody"));

            this.GetNameEnabled = false;
        }
    }
}

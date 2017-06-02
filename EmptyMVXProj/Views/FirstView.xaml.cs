using EmptyMVXProjCore.Model;
using MvvmCross.Wpf.Views;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EmptyMVXProj.Views
{
    public partial class FirstView : MvxWpfView
    {
        private ObservableCollection<Person> ListOfNames;

        public FirstView()
        {
            this.InitializeComponent();
            this.ListOfNames = new ObservableCollection<Person>();
        }
        

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            InitListOfNames();
            FlowDocument PrintingDoc = new FlowDocument();
            Paragraph HeaderPara = new Paragraph();
            HeaderPara.Inlines.Add(new Run("List of people in the building"));

            Paragraph peoplePara = new Paragraph();
            if (ListOfNames.Count > 0)
            {
                foreach (var person in ListOfNames)
                {
                    peoplePara.Inlines.Add(new Run(person.DisplayName + "\n"));
                }
            }

            PrintingDoc.Blocks.Add(HeaderPara);
            PrintingDoc.Blocks.Add(peoplePara);

            var pd = new PrintDialog();

            IDocumentPaginatorSource idpSource = PrintingDoc;

            pd.PrintDocument(idpSource.DocumentPaginator, "This is my attempt at printing");
        }

        private void InitListOfNames()
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
        }
    }
}

namespace EmptyMVXProjCore.Model
{
    public class Person
    {
        private string title;
        private string forename;
        private string surname;
        private string displayName;

        public Person(string title, string forename, string surname)
        {
            this.Title = title;
            this.Forename = forename;
            this.Surname = surname;

            this.DisplayName = $"{this.title}. {this.Forename} {this.Surname}";
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Forename
        {
            get { return forename; }
            set { forename = value; }
        }
        
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
    }
}

using System.Collections.ObjectModel;

namespace Recipe_05_11
{
    public class Person
    {
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Photo
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }

    public class People : Collection<Person>
    {
        public People()
        {
            this.Add(new Person()
                         {
                             FirstName = "Nelly",
                             LastName = "Blinks",
                             Age = 26,
                             Photo = "nelly.png"
                         });
            this.Add(new Person()
                         {
                             FirstName = "Sam",
                             LastName = "Bourts",
                             Age = 24,
                             Photo = "author.png"
                         });
        }
    }
}
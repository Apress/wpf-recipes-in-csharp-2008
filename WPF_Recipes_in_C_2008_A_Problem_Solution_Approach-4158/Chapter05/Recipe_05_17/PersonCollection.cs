using System.Collections.ObjectModel;
using Recipe_05_17;

namespace Recipe_05_17
{
    public class PersonCollection
        : ObservableCollection<Person>
    {
        public PersonCollection()
        {
            // Load the collection with dummy data
            //
            Add(new Person(){FirstName = "Elin",
                             LastName = "Binkles",
                             Age = 26,
                             Occupation = "Professional"});

            Add(new Person(){FirstName = "Samuel",
                             LastName = "Bourts",
                             Age = 28,
                             Occupation = "Engineer"});

            Add(new Person(){FirstName = "Alan",
                             LastName = "Jonesy",
                             Age = 37,
                             Occupation = "Engineer"});

            Add(new Person(){FirstName = "Sam",
                             LastName = "Nobles",
                             Age = 25,
                             Occupation = "Engineer"});
        }
    }
}
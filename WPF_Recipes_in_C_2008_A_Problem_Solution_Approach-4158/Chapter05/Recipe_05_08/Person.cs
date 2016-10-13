using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Recipe_05_08
{
    public class Person : INotifyPropertyChanged
    {
        private string firstName;
        private int age;
        private string lastName;
        private string status;
        private string occupation;

        private AddPersonCommand addPersonCommand;
        private SetOccupationCommand setOccupationCommand;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if(firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if(this.lastName != value)
                {
                    this.lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if(this.age != value)
                {
                    this.age = value;
                    OnPropertyChanged("Age");
                }
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                if(this.status != value)
                {
                    this.status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        public string Occupation
        {
            get
            {
                return occupation;
            }
            set
            {
                if(this.occupation != value)
                {
                    this.occupation = value;
                    OnPropertyChanged("Occupation");
                }
            }
        }


        /// Gets an AddPersonCommand for data binding
        public AddPersonCommand Add
        {
            get
            {
                if(addPersonCommand == null)
                    addPersonCommand = new AddPersonCommand(this);

                return addPersonCommand;
            }
        }


        /// Gets a SetOccupationCommand for data binding
        public SetOccupationCommand SetOccupation
        {
            get
            {
                if(setOccupationCommand == null)
                    setOccupationCommand = new SetOccupationCommand(this);

                return setOccupationCommand;
            }
        }

        #region INotifyPropertyChanged Members

        /// Implement INotifyPropertyChanged to notify the binding
        /// targets when the values of properties change.
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(
                    this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }

    public class AddPersonCommand : ICommand
    {
        private Person person;

        public AddPersonCommand(Person person)
        {
            this.person = person;

            this.person.PropertyChanged +=
                new PropertyChangedEventHandler(person_PropertyChanged);
        }

        // Handle the PropertyChanged event of the person, to raise the 
        // CanExecuteChanged event
        private void person_PropertyChanged(
            object sender, PropertyChangedEventArgs e)
        {
            if(CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        #region ICommand Members

        /// The command can execute if there are valid values 
        /// for the person's FirstName, LastName and Age properties,
        /// and if it hasn't already been executed and had its 
        /// Status property set.
        public bool CanExecute(object parameter)
        {
            if(!string.IsNullOrEmpty(person.FirstName))
                if(!string.IsNullOrEmpty(person.LastName))
                    if(person.Age > 0)
                        if(string.IsNullOrEmpty(person.Status))
                            return true;

            return false;
        }

        public event EventHandler CanExecuteChanged;

        /// When the command is executed, update the 
        /// status property of the person.
        public void Execute(object parameter)
        {
            person.Status = 
                string.Format("Added {0} {1}", 
                              person.FirstName, person.LastName);
        }

        #endregion
    }

    public class SetOccupationCommand : ICommand
    {
        private Person person;

        public SetOccupationCommand(Person person)
        {
            this.person = person;

            this.person.PropertyChanged +=
                new PropertyChangedEventHandler(person_PropertyChanged);
        }

        // Handle the PropertyChanged event of the person, to raise the 
        // CanExecuteChanged event
        private void person_PropertyChanged(
            object sender, PropertyChangedEventArgs e)
        {
            if(CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        #region ICommand Members

        /// The command can execute if the person has been added, 
        /// which means its Status will be set, and if the occupation
        /// parameter is not null
        public bool CanExecute(object parameter)
        {
            if(!string.IsNullOrEmpty(parameter as string))
                if(!string.IsNullOrEmpty(person.Status))
                    return true;

            return false;
        }

        public event EventHandler CanExecuteChanged;

        /// When the command is executed, set the Occupation
        /// property of the person, and update the Status.
        public void Execute(object parameter)
        {
            // Get the occupation string from the command paramter
            person.Occupation = parameter.ToString();

            person.Status = 
                string.Format("Added {0} {1}, {2}", 
                              person.FirstName, person.LastName, person.Occupation);
        }
        #endregion
    }
}
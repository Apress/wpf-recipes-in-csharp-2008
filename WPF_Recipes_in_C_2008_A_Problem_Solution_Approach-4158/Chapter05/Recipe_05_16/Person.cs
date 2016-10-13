using System.ComponentModel;

namespace Recipe_05_16
{
    public class Person
        : INotifyPropertyChanged,
          IDataErrorInfo
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person()
        {
            FirstName = "spod";
        }
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

        #region INotifyPropertyChanged Members

        /// Implement INotifyPropertyChanged to notify the binding
        /// targets when the values of properties change.
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(
            string propertyName)
        {
            if(this.PropertyChanged != null)
            {
                // Raise the PropertyChanged event
                this.PropertyChanged(
                    this,
                    new PropertyChangedEventArgs(
                        propertyName));
            }
        }

        #endregion

        #region IDataErrorInfo Members

        // Implement IDataErrorInfo to return custom
        // error messages when a property value
        // is invalid.

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                // Return an empty string if there are no errrors
                string message = string.Empty;

                switch(propertyName)
                {
                    case "FirstName":
                        if(string.IsNullOrEmpty(firstName))
                            message = "A person must have a first name.";
                        break;

                    case "LastName":
                        if(string.IsNullOrEmpty(lastName))
                            message = "A person must have a last name.";
                        break;

                    case "Age":
                        if(age < 1)
                            message = "A person must have an age.";
                        break;

                    case "Occupation":
                        if(string.IsNullOrEmpty(firstName))
                            message = "A person must have an occupation.";
                        break;
                    default:
                        break;
                }

                return message;
            }
        }

        #endregion
    }
}
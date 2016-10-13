
using System.Collections.ObjectModel;

namespace Recipe_05_13
{
    public class DataItem
    {
        public double Amount
        {
            get;
            set;
        }

        public bool IsPositive
        {
            get
            {
                return Amount >= 0;
            }
        }
    }

    public class DataItems : Collection<DataItem>
    {
        public DataItems()
        {
            this.Add(new DataItem(){Amount=50});
            this.Add(new DataItem(){Amount=80});
            this.Add(new DataItem(){Amount=-45});
            this.Add(new DataItem(){Amount=20});
            this.Add(new DataItem(){Amount=-35});
            this.Add(new DataItem(){Amount=-65});
        }
    }
}
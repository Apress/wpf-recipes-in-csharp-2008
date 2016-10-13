
using System.Collections.ObjectModel;

namespace Using_Value_Converters
{
    public class DataItem
    {
        public double Percent { get; set; }
    }

    public class DataItems : Collection<DataItem>
    {
        public DataItems()
        {
            this.Add(new DataItem(){Percent=50});
            this.Add(new DataItem(){Percent=80});
            this.Add(new DataItem(){Percent=-45});
            this.Add(new DataItem(){Percent=20});
            this.Add(new DataItem(){Percent=-35});
            this.Add(new DataItem(){Percent=-65});
        }
    }
}

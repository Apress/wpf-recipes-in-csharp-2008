using System.Collections.ObjectModel;

namespace Recipe_05_14
{
    public class TaskItem
    {
        public string Name
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public int Priority
        {
            get;
            set;
        }
    }

    public class TaskList
        : Collection<TaskItem>
    {
        public TaskList()
            : base()
        {
            Add(new TaskItem()
                    {
                        Name = "Shopping",
                        Description = "Buy bread and milk",
                        Priority = 2
                    });

            Add(new TaskItem()
                    {
                        Name = "Presentation",
                        Description = "Prepare presentation for Tuesday",
                        Priority = 2
                    });

            Add(new TaskItem()
                    {
                        Name = "Birthday",
                        Description = "Buy dad's present",
                        Priority = 1
                    });

            Add(new TaskItem()
                    {
                        Name = "Laundry",
                        Description = "Do washing",
                        Priority = 3
                    });


            Add(new TaskItem()
                    {
                        Name = "Holiday",
                        Description = "Book plane tickets",
                        Priority = 1
                    });

            Add(new TaskItem()
                    {
                        Name = "Exercise",
                        Description = "Go to gym",
                        Priority = 2
                    });
        }
    }
}
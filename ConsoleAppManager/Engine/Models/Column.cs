using System.Collections.Generic;

namespace TaskManagementEngine.Models
{
    public class Column
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }

        public Column()
        {
            Tasks = new List<Task>();
        }
    }
}

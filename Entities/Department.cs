using System.Collections.Generic;

namespace WebAPIApplication.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
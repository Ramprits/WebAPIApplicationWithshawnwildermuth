using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIApplication.Entities
{
    public class Employee
    {
        [Key]
        [Column(Order =1)]
        public int Id { get; set; }
        [Column(Order =2)]
        public string FirstName { get; set; }
        [Column(Order =3)]
        public string LastName { get; set; }
        [Column(Order =4)]
        public string Gender { get; set; }
        [Column(Order =5)]
        public string Title { get; set; }
        [Column(Order =6)]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
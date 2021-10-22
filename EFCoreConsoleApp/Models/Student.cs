using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Models
{
    [Table("Students")]
    public class Student
    {
        public int Id { get; set; }
        [Column("Last_Name")]
        public string LastName { get; set; }
        [Column("First_Name")]
        public string FirstName { get; set; }
        [Column("School_Id")]
        public int SchoolId { get; set; }
    }
}

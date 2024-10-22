using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORECRUD.Models
{
    public class People
    {
        [Key]
        public int PeopleID { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Surname { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        public string? City { get; set; }

        public int DepartmentID { get; set; }
        public Department _Depart { get; set; }

    }
}

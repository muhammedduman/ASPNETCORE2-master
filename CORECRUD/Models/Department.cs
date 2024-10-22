using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORECRUD.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Column(TypeName="VARCHAR(100)")]
        //[StringLength(100)]
        public string DepartmentName { get; set; }

        [Column(TypeName = "VARCHAR(500)")] 
        public string Description1 { get; set; }

        [Column(TypeName = "VARCHAR(5000)")]
        public string Description2 { get; set; }
        public IList<People> _People { get; set; }


    }
}

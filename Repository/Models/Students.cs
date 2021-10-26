using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.Models
{
    public partial class Students
    {
        public Students()
        {
            StudentSubjects = new HashSet<StudentSubjects>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(8)]
        public string StudentCode { get; set; }

        [InverseProperty("IdStudentNavigation")]
        public virtual ICollection<StudentSubjects> StudentSubjects { get; set; }
    }
}

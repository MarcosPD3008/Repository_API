using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            StudentSubjects = new HashSet<StudentSubjects>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string SubjectCode { get; set; }

        [InverseProperty("IdSubjectNavigation")]
        public virtual ICollection<StudentSubjects> StudentSubjects { get; set; }
    }
}

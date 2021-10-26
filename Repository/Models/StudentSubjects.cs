using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.Models
{
    public partial class StudentSubjects
    {
        [Key]
        public int Id { get; set; }
        public int IdStudent { get; set; }
        public int IdSubject { get; set; }

        [ForeignKey(nameof(IdStudent))]
        [InverseProperty(nameof(Students.StudentSubjects))]
        public virtual Students IdStudentNavigation { get; set; }
        [ForeignKey(nameof(IdSubject))]
        [InverseProperty(nameof(Subjects.StudentSubjects))]
        public virtual Subjects IdSubjectNavigation { get; set; }
    }
}

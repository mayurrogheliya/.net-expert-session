using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace expertsession.Models
{
    public class StudentRegister
    {
        [Key]
        public int student_id { get; set; }

        [Required,NotNull]
        public string student_name { get; set; }

        [Required,NotNull]
        public string student_branch { get; set; }

        [Required]
        public int student_roll { get; set; }
    }
}

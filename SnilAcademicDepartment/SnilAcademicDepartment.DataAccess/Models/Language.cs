using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SnilAcademicDepartment.DataAccess.Models.Education;

namespace SnilAcademicDepartment.DataAccess.Models
{
	[Table("Language")]
    public partial class Language
    {
        public int LanguageId { get; set; }

        public string LanguageName { get; set; }

        public int LanguageCode { get; set; }
		
		/// Gets or sets the student one-to-many relationship.
		/// 
		public virtual ICollection<EducationBlock> EducationBlocks { get; set; } = new HashSet<EducationBlock>();

        public virtual ICollection<Lecture> Lectures { get; set; } = new HashSet<Lecture>();

        public virtual ICollection<Person> People { get; set; } = new HashSet<Person>();

        public virtual ICollection<PreView> PreViews { get; set; } = new HashSet<PreView>();

        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();

        public virtual ICollection<Seminar> Seminars { get; set; } = new HashSet<Seminar>();

        public virtual ICollection<Specialisation> Specialisations { get; set; } = new HashSet<Specialisation>();

		public virtual ICollection<Students> Students { get; set; } = new HashSet<Students>();

		public virtual ICollection<Diploma> Diplomas { get; set; } = new HashSet<Diploma>();
	}
}

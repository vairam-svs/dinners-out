namespace DinnersOut.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClassCourse")]
    public partial class ClassCourse
    {
        public int Id { get; set; }

        public int? ClassId { get; set; }

        public int? CourseId { get; set; }

        public int? LocationId { get; set; }

        [Required]//(ErrorMessage = "Start Date is Required")]
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Class Class { get; set; }

        public virtual Course Course { get; set; }

        public virtual Location Location { get; set; }
    }
}

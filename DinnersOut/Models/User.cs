namespace DinnersOut.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public DateTime? JoinDate { get; set; }

        public bool? StatusInd { get; set; }
    }
}

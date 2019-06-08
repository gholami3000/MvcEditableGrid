namespace MvcEditableGrid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EditablePerson")]
    public partial class EditablePerson
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Family { get; set; }

        [Range(18, 56, ErrorMessage = "Age Must be between 18 to 60")]
        public int Age { get; set; }
    }
}

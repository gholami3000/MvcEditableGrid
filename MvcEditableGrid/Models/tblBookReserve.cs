namespace MvcEditableGrid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hoir_ho.tblBookReserve")]
    public partial class tblBookReserve
    {
        [Key]
        public int ReserveId { get; set; }

        public int BookId { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }

        public virtual tblBook tblBook { get; set; }
    }
}

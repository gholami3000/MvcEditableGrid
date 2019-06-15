namespace MvcEditableGrid.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookReserveContext : DbContext
    {
        public BookReserveContext()
            : base("name=BookReserveContext")
        {
        }

        public virtual DbSet<tblBook> tblBook { get; set; }
        public virtual DbSet<tblBookReserve> tblBookReserve { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblBook>()
                .HasMany(e => e.tblBookReserve)
                .WithRequired(e => e.tblBook)
                .WillCascadeOnDelete(false);
        }
    }
}

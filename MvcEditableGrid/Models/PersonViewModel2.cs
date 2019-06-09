namespace MvcEditableGrid.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class PersonViewModel2
    {
        public int Id { get; set; }

        public IList<EditablePerson> Persons
        {
            get; set;
        }
    }
}

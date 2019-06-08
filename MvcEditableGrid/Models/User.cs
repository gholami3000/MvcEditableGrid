using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcEditableGrid.Models
{

    public class User
    {
        [Key]
        public int Id { set; get; }
        public string Name { get; set; }
        public IList<UserInterest> Interests
        {
            get; set;
        }

       
    }
}
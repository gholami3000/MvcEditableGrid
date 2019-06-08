using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcEditableGrid.Models
{
   
    public class UserInterest
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string InterestText { set; get; }
        public int Option { set; get; }
    }
}
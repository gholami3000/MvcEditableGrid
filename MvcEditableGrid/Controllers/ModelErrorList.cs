using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEditableGrid
{
    public class ModelErrorList
    {
        public int RowId { get; set; }
        public int ItemId { get; set; }
        public string FieldName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
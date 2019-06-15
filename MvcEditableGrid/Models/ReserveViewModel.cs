using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEditableGrid.Models
{
    public class ReserveViewModel
    {

        //public tblBook Book { get; set; }
        //public tblBookReserve Reserve { get; set; }

        //public IList<tblBookReserve> Reservs { get; set; }

        //public IList<tblBook> Books { get; set; }
        //public int Id { get; set; }
        public IList<tblBookReserve> Reserves
        {
            get; set;
        }

    }
}
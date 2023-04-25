using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenPark.Models
{

    public class ReservationDetails
    {
        public string name { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public int tableNumber { get; set; }
        public int numberOfPeople { get; set; }
        public int totalPrice { get; set; }
        public string me_reference_id { get; set; }
        public List<Selection> selections { get; set; }
    }

    public class Selection
    {
        public int customer { get; set; }
        public string platillo { get; set; }
        public string bebida { get; set; }
    }

    public class TableSummary
    {
        public int TableNumber { get; set; }
        public int Occupied { get; set; }
        public string Class { get; set; }
    }
}
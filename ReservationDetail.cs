//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KitchenPark
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReservationDetail
    {
        public long ReservationDetailsId { get; set; }
        public string me_reference_id { get; set; }
        public string payment_request_id { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public int tableNumber { get; set; }
        public int numberOfPeople { get; set; }
        public int totalPrice { get; set; }
        public string platillo1 { get; set; }
        public string bebida1 { get; set; }
        public string observaciones1 { get; set; }
        public string platillo2 { get; set; }
        public string bebida2 { get; set; }
        public string observaciones2 { get; set; }
        public string platillo3 { get; set; }
        public string bebida3 { get; set; }
        public string observaciones3 { get; set; }
        public string platillo4 { get; set; }
        public string bebida4 { get; set; }
        public string observaciones4 { get; set; }
        public System.DateTime RequestedOn { get; set; }
        public string status { get; set; }
        public Nullable<int> qrTicket { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Spedycja.Model.EntityModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Load
    {
        public Load()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Weight { get; set; }
        public Nullable<int> IdType { get; set; }
    
        public virtual TypesFreight TypesFreight { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
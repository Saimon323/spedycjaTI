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
    
    public partial class Comment
    {
        public int id { get; set; }
        public string Text { get; set; }
        public int idWorker { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int idOrder { get; set; }
    
        public virtual Order Order { get; set; }
    }
}

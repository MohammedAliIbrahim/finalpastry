//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication13.Models
{
    using System;
    using System.Collections.Generic;
    ////this class is unused now . it was part of the previous attempts 
    public partial class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Nullable<int> Amount { get; set; }
        public string ShoppingCartId { get; set; }
        public int pieid { get; set; }
    
        public virtual pie pie { get; set; }
    }
}

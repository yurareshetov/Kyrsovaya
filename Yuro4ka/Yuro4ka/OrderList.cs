//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Yuro4ka
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderList()
        {
            this.ProductOrderSV = new HashSet<ProductOrderSV>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Number { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Logo { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string Delivery { get; set; }
    
        public virtual OrderList OrderList1 { get; set; }
        public virtual OrderList OrderList2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrderSV> ProductOrderSV { get; set; }
    }
}
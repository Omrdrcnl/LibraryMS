//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryMS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAction()
        {
            this.tblPenal = new HashSet<tblPenal>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Book { get; set; }
        public Nullable<int> Member { get; set; }
        public Nullable<int> Employee { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public Nullable<System.DateTime> ProcessDate { get; set; }
        public Nullable<bool> Process { get; set; }
    
        public virtual tblBook tblBook { get; set; }
        public virtual tblEmployee tblEmployee { get; set; }
        public virtual tblMember tblMember { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPenal> tblPenal { get; set; }
    }
}

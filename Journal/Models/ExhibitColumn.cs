//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JournalProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExhibitColumn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExhibitColumn()
        {
            this.ExhibitDatas = new HashSet<ExhibitData>();
        }
    
        public int id { get; set; }
        public int exhibit_id { get; set; }
        public string title_en { get; set; }
        public string title_az { get; set; }
    
        public virtual Exhibit Exhibit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExhibitData> ExhibitDatas { get; set; }
    }
}

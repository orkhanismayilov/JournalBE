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
    
    public partial class Tag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tag()
        {
            this.ArticlesTags = new HashSet<ArticlesTag>();
        }
    
        public int id { get; set; }
        public string title_en { get; set; }
        public string title_az { get; set; }
        public string alias { get; set; }
        public string link_short { get; set; }
        public string link { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArticlesTag> ArticlesTags { get; set; }
    }
}

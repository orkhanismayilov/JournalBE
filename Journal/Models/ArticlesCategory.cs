//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Journal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArticlesCategory
    {
        public int id { get; set; }
        public int article_id { get; set; }
        public int category_id { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual Category Category { get; set; }
    }
}
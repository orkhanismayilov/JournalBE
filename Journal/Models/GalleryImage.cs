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
    
    public partial class GalleryImage
    {
        public int id { get; set; }
        public int gallery_id { get; set; }
        public int image_id { get; set; }
    
        public virtual Gallery Gallery { get; set; }
        public virtual Image Image { get; set; }
    }
}

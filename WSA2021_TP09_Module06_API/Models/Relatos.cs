//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSA2021_TP09_Module06_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Relatos
    {
        public int id { get; set; }
        public string relato { get; set; }
        public string imagem { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public Nullable<int> usuarioid { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}

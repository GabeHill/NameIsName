//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NameIsNameCharacterGenerator.Services
{
    using System;
    using System.Collections.Generic;
    
    public partial class Equipment
    {
        public int EquipmentId { get; set; }
        public int CharcterID { get; set; }
        public string Equipment1 { get; set; }
    
        public virtual Character Character { get; set; }
    }
}

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
    
    public partial class Character
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Character()
        {
            this.Bonds = new HashSet<Bond>();
            this.PersonalityTraits = new HashSet<PersonalityTrait>();
            this.Ideals = new HashSet<Ideal>();
            this.Equipments = new HashSet<Equipment>();
            this.Flaws = new HashSet<Flaw>();
            this.Features_Traits = new HashSet<Features_Traits>();
            this.Prof_Lang = new HashSet<Prof_Lang>();
        }
    
        public int CharcterID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }
        public Nullable<int> Str { get; set; }
        public Nullable<int> Dex { get; set; }
        public Nullable<int> Con { get; set; }
        public Nullable<int> Int { get; set; }
        public Nullable<int> Wis { get; set; }
        public Nullable<int> Cha { get; set; }
        public Nullable<int> Prof { get; set; }
        public Nullable<int> Acrobatics { get; set; }
        public Nullable<int> AniamlHandling { get; set; }
        public Nullable<int> Arcana { get; set; }
        public Nullable<int> Athletics { get; set; }
        public Nullable<int> Deception { get; set; }
        public Nullable<int> History { get; set; }
        public Nullable<int> Insight { get; set; }
        public Nullable<int> Intimidation { get; set; }
        public Nullable<int> Investigation { get; set; }
        public Nullable<int> Medicine { get; set; }
        public Nullable<int> Nature { get; set; }
        public Nullable<int> Perception { get; set; }
        public Nullable<int> Performance { get; set; }
        public Nullable<int> Persuasion { get; set; }
        public Nullable<int> Religion { get; set; }
        public Nullable<int> SlightOfHand { get; set; }
        public Nullable<int> Stealth { get; set; }
        public Nullable<int> Survival { get; set; }
        public Nullable<int> AC { get; set; }
        public Nullable<int> Speed { get; set; }
        public Nullable<int> HP { get; set; }
        public string HitDice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bond> Bonds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalityTrait> PersonalityTraits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ideal> Ideals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipment> Equipments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flaw> Flaws { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Features_Traits> Features_Traits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prof_Lang> Prof_Lang { get; set; }
    }
}

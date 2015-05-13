using System;

namespace ASFbuilder.Equipment
{
    class Weapon : Item
    {
        public int Damage { get; private set; }                                 // Weapon damage
        public int Heat { get; private set; }                                   // Heat generated
        public int AmmoPerTon { get; private set; }                             // Rounds per ton of ammo
        public string Range { get; private set; }                               // AT2 Range
        public string Type { get; private set; }                                // Weapon Type

        //Constructors
        //Non-default constructor that initializes all properties
        public Weapon(int bv1, int cost, decimal mass, string name, 
            int damage, int heat, int ammo, string range, string type)
            : base(bv1, cost, mass, name)
        {
            Damage = base.ValidateInt(damage);
            Heat = base.ValidateInt(heat);
            AmmoPerTon = base.ValidateInt(ammo);
            Range = base.ValidateString(range);            
            Type = base.ValidateString(type);
        }
        //Non-default constructor that does not take BV parameter
        public Weapon(int cost, decimal mass, string name, int damage,
            int heat, int ammo, string range, string type)
            : base(cost, mass, name)
        {
            Damage = base.ValidateInt(damage);
            Heat = base.ValidateInt(heat);
            AmmoPerTon = base.ValidateInt(ammo);
            Range = base.ValidateString(range);          
            Type = base.ValidateString(type);
        }
    }        
}
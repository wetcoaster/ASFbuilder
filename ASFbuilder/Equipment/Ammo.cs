using System;

namespace ASFbuilder.Equipment
{
    class Ammo : Item
    {
        public int AmmoPerTon { get; private set; }                             // Rounds per ton of ammo
        
        // Constructor
        public Ammo(int bv1, int cost, decimal mass, string name, int ammo)
            : base(bv1, cost, mass, name)
        {
            AmmoPerTon = base.ValidateInt(ammo);
        }
    }    
}
using System;

namespace ASFbuilder.Equipment
{
    class HeatSinks : Item
    {
        public int Dissipation { get; private set; }        // Amount of heat dissipated per turn

        // Constructor
        public HeatSinks(int bv1, int cost, decimal mass, string name, int dissipation)
            : base(bv1, cost, mass, name)
        {
            Dissipation = base.ValidateInt(dissipation);
        }
    }
}

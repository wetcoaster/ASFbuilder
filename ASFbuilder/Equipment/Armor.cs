using System;

namespace ASFbuilder.Equipment
{
    class Armor : Item
    {
        public int PointsPerTonne { get; private set; }
        public decimal Multiplier { get; private set; }
        // Constructor
        public Armor(int bv1, int cost, decimal mass, string name, int points, decimal multiplier)
            : base(bv1, cost, mass, name)
        {
            PointsPerTonne = base.ValidateInt(points);
            Multiplier = multiplier;
        }
    }
}
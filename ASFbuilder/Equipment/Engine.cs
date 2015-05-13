using System;

namespace ASFbuilder.Equipment
{
    class Engine : Item
    {
        public int EngineSize { get; private set; }                             // Size of engine
        public string EngineType { get; private set; }                          // Type of engine

        // Constructor
        public Engine(int size, decimal mass, string name, string type)
            : base(mass, name)
        {
            EngineSize = base.ValidateInt(size);
            EngineType = base.ValidateString(type);
        }
    }
}
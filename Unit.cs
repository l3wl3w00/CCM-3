using System;

namespace Meres3
{
    public enum Unit
    {
        Volt, 
        KiloOhm
    }
    
    public static class UnitMethods
    {
        private const string VoltConfCommand = ":CONF:VOLT:DC";
        private const string ResConfCommand = ":CONF:RES";
        public static string GetCommand(this Unit unit)
        {
            switch (unit)
            {
                case Unit.Volt: return VoltConfCommand;
                case Unit.KiloOhm: return ResConfCommand;
                default:
                    throw new ArgumentOutOfRangeException(nameof(unit), unit, null);
            }
        }
    }
}
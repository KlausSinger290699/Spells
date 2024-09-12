using System;

namespace SCD.Spells.Unused.Helpers
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class AutoInstantiateSpellAttribute : Attribute
    {
        public string DataPath { get; }

        public AutoInstantiateSpellAttribute(string dataPath)
        {
            DataPath = dataPath;
        }
    }
}

using System;
using SCD.Spells.Core;

namespace SCD.Spells.SpellComposite.CompositeContracts
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class CompositeTypeAttribute : Attribute
    {
        public CompositeType CompositeType { get; }
        public CompositeTypeAttribute(CompositeType compositeType) => CompositeType = compositeType;
    }
}
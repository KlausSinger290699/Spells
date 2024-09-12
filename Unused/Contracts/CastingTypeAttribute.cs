using System;
using SCD.Spells.Core;

namespace SCD.Spells.Unused.Contracts
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class CastingTypeAttribute : Attribute
    {
        public CastingType CastingType { get; }
        public CastingTypeAttribute(CastingType castingType) => CastingType = castingType;
    }
}

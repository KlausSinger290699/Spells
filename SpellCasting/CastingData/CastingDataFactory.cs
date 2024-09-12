using SCD.Spells.Core;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingData
{
    public static class CastingDataFactory
    {
        private static readonly CastingTypeMapping _mapping;

        static CastingDataFactory() => _mapping = Resources.Load<CastingTypeMapping>(nameof(CastingTypeMapping));

        public static ScriptableObject GetSpellDataForType(CastingType castingType)
        {
            _mapping.Mappings.TryGetValue(castingType, out var scriptableObject);
            return scriptableObject;
        }
    }
}
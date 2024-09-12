using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SCD.Spells.Core;
using SCD.Spells.SpellCasting.CastingContracts;
using SCD.Spells.Unused.Contracts;
using UnityEngine;

namespace SCD.Spells.Unused.Factories
{
    public static class CastingDataFactoryEnums
    {
        private static readonly Dictionary<CastingType, string> _spellDataPathMapping = new();

        static CastingDataFactoryEnums()
        {
            _spellDataPathMapping.Clear();
            
            var allSpellTypes = Assembly.GetAssembly(typeof(ISpell)).GetTypes()
                .Where(t => typeof(ISpell).IsAssignableFrom(t)
                            && typeof(ICasting).IsAssignableFrom(t)
                            && !t.IsInterface
                            && !t.IsAbstract);

            foreach (var spellType in allSpellTypes)
            {
                var attribute = (CastingTypeAttribute)Attribute.GetCustomAttribute(spellType, typeof(CastingTypeAttribute));
                if (attribute != null)
                {
                    string dataPath = $"{attribute.CastingType}_Casting_Data";
                    _spellDataPathMapping.Add(attribute.CastingType, dataPath);
                }
            }
        }

        public static ScriptableObject GetSpellDataForType(CastingType castingType)
        {
            _spellDataPathMapping.TryGetValue(castingType, out var dataPath);
            return Resources.Load(dataPath) as ScriptableObject;
        }
    }
}
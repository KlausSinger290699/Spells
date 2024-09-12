using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SCD.Spells.Core;
using SCD.Spells.Unused.Helpers;
using UnityEngine;

namespace SCD.Spells.Unused.Factories
{
    public static class SpellDataFactoryAttributes
    {
        private static readonly Dictionary<Type, string> _spellDataPathMapping = new();

        static SpellDataFactoryAttributes()
        {
            var allSpellTypes = Assembly.GetAssembly(typeof(ISpell)).GetTypes()
                .Where(t => typeof(ISpell).IsAssignableFrom(t) 
                            && !t.IsInterface 
                            && !t.IsAbstract 
                            && t.GetCustomAttribute<AutoInstantiateSpellAttribute>() != null);

            foreach (var spellType in allSpellTypes)
            {
                var attribute = spellType.GetCustomAttribute<AutoInstantiateSpellAttribute>();
                _spellDataPathMapping.Add(spellType, attribute.DataPath);
            }
        }
        
        public static ScriptableObject GetSpellDataForType(Type spellType)
        {
            _spellDataPathMapping.TryGetValue(spellType, out var dataPath);
            return Resources.Load(dataPath) as ScriptableObject;
        }
    }
}
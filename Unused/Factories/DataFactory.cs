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
    //Needs to be worked on
    public static class DataFactory<TEnum>
        where TEnum : Enum
    {
        private static readonly Dictionary<TEnum, string> _spellDataPathMapping = new();

        static DataFactory()
        {
            _spellDataPathMapping.Clear();

            string suffix = DetermineSuffix(typeof(TEnum));

            var allSpellTypes = Assembly.GetAssembly(typeof(ISpell)).GetTypes()
                .Where(t => typeof(ISpell).IsAssignableFrom(t)
                            && typeof(ICasting).IsAssignableFrom(t)
                            && !t.IsInterface
                            && !t.IsAbstract);

            foreach (var spellType in allSpellTypes)
            {
                var attributes = spellType.GetCustomAttributes(typeof(CastingTypeAttribute), false);
                if (attributes.Length > 0)
                {
                    var attribute = (CastingTypeAttribute)attributes[0];
                    TEnum castingTypeEnum = (TEnum)Enum.Parse(typeof(TEnum), attribute.CastingType.ToString());
                    string dataPath = $"{castingTypeEnum}_{suffix}";
                    _spellDataPathMapping.Add(castingTypeEnum, dataPath);
                }
            }
        }

        public static ScriptableObject GetSpellDataForType(TEnum castingType)
        {
            _spellDataPathMapping.TryGetValue(castingType, out var dataPath);
            return Resources.Load(dataPath) as ScriptableObject;
        }

        private static string DetermineSuffix(Type enumType)
        {
            if (enumType == typeof(CastingType))
                return "Casting_Data";
            if (enumType == typeof(DecoratorType))
                return "Decorator_Data";
            if (enumType == typeof(CompositeType))
                return "Composite_Data";

            throw new InvalidOperationException($"Unsupported enum type: {enumType}");
        }
    }

}

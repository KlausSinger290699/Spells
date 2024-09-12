using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SCD.Spells.Core;
using SCD.Spells.SpellDecorator.DecoratorContracts;
using UnityEngine;

namespace SCD.Spells.SpellDecorator.DecoratorData
{
    public static class DecoratorDataFactory
    {
        private static readonly Dictionary<DecoratorType, string> _decoratorDataPathMapping = new();

        static DecoratorDataFactory()
        {
            _decoratorDataPathMapping.Clear();
            
            var allSpellTypes = Assembly.GetAssembly(typeof(ISpell)).GetTypes()
                .Where(t => typeof(ISpell).IsAssignableFrom(t)
                            && typeof(IDecorator).IsAssignableFrom(t)
                            && !t.IsInterface
                            && !t.IsAbstract);

            foreach (var spellType in allSpellTypes)
            {
                var attribute = (DecoratorTypeAttribute)Attribute.GetCustomAttribute(spellType, typeof(DecoratorTypeAttribute));
                if (attribute != null)
                {
                    string dataPath = $"{attribute.DecoratorType}_Decorator_Data";
                    _decoratorDataPathMapping.Add(attribute.DecoratorType, dataPath);
                }
            }
        }

        public static ScriptableObject GetDecoratorForType(DecoratorType castingType)
        {
            _decoratorDataPathMapping.TryGetValue(castingType, out var dataPath);
            return Resources.Load(dataPath) as ScriptableObject;
        }
    }
}
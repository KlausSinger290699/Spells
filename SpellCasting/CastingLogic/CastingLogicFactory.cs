using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SCD.Spells.Core;
using SCD.Spells.SpellCasting.CastingContracts;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingLogic
{
    public static class CastingLogicFactory
    {
        private static readonly Dictionary<CastingType, ISpell> _spells = new();

        public static void Initialize(Transform playerTransform)
        {
            _spells.Clear();
            
            var allSpellTypes = Assembly.GetAssembly(typeof(ISpell)).GetTypes()
                .Where(t => typeof(ISpell).IsAssignableFrom(t)
                            && typeof(ICasting).IsAssignableFrom(t)
                            && !t.IsInterface
                            && !t.IsAbstract);

            foreach (var spellType in allSpellTypes)
            {
                var constructor = spellType.GetConstructor(new[] { typeof(Transform) });
                if (constructor != null)
                {
                    ISpell spell = constructor.Invoke(new object[] { playerTransform }) as ISpell;
                    ICasting casting = spell as ICasting;
        
                    if (casting != null)
                        _spells.Add(casting.CastingType, spell);
                }
            }
        }
        
        public static ISpell GetSpellForType(CastingType castingType)
        {
            if (_spells.TryGetValue(castingType, out var spell))
            {
                return spell;
            }
            else
            {
                Debug.LogError($"No spell found for casting type: {castingType}");
                return null;
            }
        }

    }
}


/*
            foreach (var spellType in allSpellTypes)
            {
                ISpell spell = Activator.CreateInstance(spellType) as ISpell;
                ICasting casting = spell as ICasting;
                
                if (casting != null)
                    _spells.Add(casting.CastingType, spell);
            }
*/
using SCD.Spells.SpellCasting.CastingLogic;
using SCD.Spells.SpellDecorator.DecoratorLogic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SCD.Spells.Core
{
    public partial class SpellManager
    {
#pragma warning disable 0414
        [SerializeField] private bool _hideTests = true;
#pragma warning restore 0414
        
        [ButtonGroup("Spell Casting Test"), HideIf(nameof(_hideTests))]
        private void CastFireball() => _equippedSpells[0].BeginCast();
        [ButtonGroup("Spell Casting Test"), HideIf(nameof(_hideTests))]
        private void CastLightning() => _equippedSpells[1].BeginCast();

        [ButtonGroup("Decoration Test"), HideIf(nameof(_hideTests))]
        private void DamageDecoration()
        {
            DecoratorLogicFactory.Initialize(CastingLogicFactory.GetSpellForType(CastingType.Fireball));
            ISpell decorator = DecoratorLogicFactory.GetDecoratorForType(DecoratorType.Damage);
            decorator.BeginCast();
        }
        [ButtonGroup("Decoration Test"), HideIf(nameof(_hideTests))]
        private void CooldownDecoration()
        {
            DecoratorLogicFactory.Initialize(CastingLogicFactory.GetSpellForType(CastingType.Lightning));
            ISpell decorator = DecoratorLogicFactory.GetDecoratorForType(DecoratorType.Cooldown);
            decorator.BeginCast();
        }
    }
}
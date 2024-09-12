using SCD.Spells.Core;
using SCD.Spells.SpellDecorator.DecoratorContracts;
using SCD.Spells.SpellDecorator.DecoratorData;
using UnityEngine;

namespace SCD.Spells.SpellDecorator.DecoratorLogic
{
    [DecoratorType(DecoratorType.Damage)]
    public class DamageDecoratorLogic : DecoratorLogicBase
    {
        private readonly ISpell _spell;

        public DamageDecoratorLogic(ISpell spell) : base(DecoratorType.Damage)
        {
            _spell = spell;
        }

        public override void BeginCast()
        {
            //Some Decoration
            Debug.Log($"Damage Decoration: {_spell.GetType().Name}");
            
            if(_decoratorData is DamageDecoratorDataSO damageDecorator)
                Debug.Log($"Decorated Stat: {nameof(damageDecorator.Damage)} = {damageDecorator.Damage}");
            
            _spell.BeginCast();
        }
    }
}
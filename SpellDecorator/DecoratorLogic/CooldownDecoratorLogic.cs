using SCD.Spells.Core;
using SCD.Spells.SpellDecorator.DecoratorContracts;
using SCD.Spells.SpellDecorator.DecoratorData;
using UnityEngine;

namespace SCD.Spells.SpellDecorator.DecoratorLogic
{
    [DecoratorType(DecoratorType.Cooldown)]
    public class CooldownDecoratorLogic : DecoratorLogicBase
    {
        private readonly ISpell _spell;
        
        public CooldownDecoratorLogic(ISpell spell) : base(DecoratorType.Cooldown)        
        {
            _spell = spell;
        }
        
        public override void BeginCast()
        {
            //Some Decoration
            Debug.Log($"Cooldown Decoration: {_spell.GetType().Name}");
            
            if(_decoratorData is CooldownDecoratorDataSO cooldownDecorator)
                Debug.Log($"Decorated Stat: {nameof(cooldownDecorator.CooldownReduction)} = {cooldownDecorator.CooldownReduction}");
            
            _spell.BeginCast();
        }
    }
}
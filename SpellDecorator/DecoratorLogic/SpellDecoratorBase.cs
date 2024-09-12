using SCD.Spells.Core;
using SCD.Spells.SpellDecorator.DecoratorContracts;
using SCD.Spells.SpellDecorator.DecoratorData;
using UnityEngine;

namespace SCD.Spells.SpellDecorator.DecoratorLogic
{
    //We could inherit from LogicBase, which is a generic class that contains the logic for the constructor the T: ICasting, IDecorator, IComposite.
    //We could also make IDecorator inherit from ISpell, so we don't have 2 interfaces here?
    public abstract class DecoratorLogicBase : ISpell, IDecorator
    {
        public DecoratorType DecoratorType { get; }

        protected readonly DecoratorDataBaseSO _decoratorData;
        
        protected DecoratorLogicBase(DecoratorType decoratorType)
        {
            DecoratorType = decoratorType;
            
            ScriptableObject _spellData = DecoratorDataFactory.GetDecoratorForType(DecoratorType);
            if (_spellData is DecoratorDataBaseSO decoratorData)
                _decoratorData = decoratorData;
        }

        public virtual void BeginCast() { }
    }
}
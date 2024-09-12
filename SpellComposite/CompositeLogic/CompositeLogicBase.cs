using SCD.Spells.Core;

namespace SCD.Spells.SpellComposite.CompositeLogic
{
    public abstract class CompositeLogicBase : ISpell
    {
        public virtual void BeginCast() { }
    }
}
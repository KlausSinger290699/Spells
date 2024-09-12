using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SCD.Spells.Core;
using SCD.Spells.SpellDecorator.DecoratorContracts;

namespace SCD.Spells.SpellDecorator.DecoratorLogic
{
    public static class DecoratorLogicFactory
    {
        private static readonly Dictionary<DecoratorType, ISpell> _spells = new();

        public static void Initialize(ISpell decoratedSpell)
        {
            _spells.Clear();
            
            var allDecoratorTypes = Assembly.GetAssembly(typeof(ISpell)).GetTypes()
                .Where(t => typeof(ISpell).IsAssignableFrom(t)
                            && typeof(IDecorator).IsAssignableFrom(t)
                            && !t.IsInterface
                            && !t.IsAbstract);

            foreach (var decoratorType in allDecoratorTypes)
            {
                var constructor = decoratorType.GetConstructor(new[] { typeof(ISpell) });
                if (constructor != null)
                {
                    ISpell spell = constructor.Invoke(new object[] { decoratedSpell }) as ISpell; //null is Questionable
                    IDecorator decorator = spell as IDecorator;
        
                    if (decorator != null)
                        _spells.Add(decorator.DecoratorType, spell);
                }
            }
        }
        
        public static ISpell GetDecoratorForType(DecoratorType decoratorType)
        {
            return _spells.TryGetValue(decoratorType, out var spell) ? spell : null;
        }
    }
}


/*
            foreach (var decoratorType in allDecoratorTypes)
            {
                ISpell spell = Activator.CreateInstance(decoratorType) as ISpell;
                IDecorator decorator = spell as IDecorator;
                
                if (decorator != null)
                    _spells.Add(decorator.DecoratorType, spell);
            }
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SCD.Spells.Core;
using SCD.Spells.Unused.Helpers;

namespace SCD.Spells.Unused.Factories
{
    public static class LogicFactory<TEnum>
        where TEnum : Enum
    {
        private static readonly Dictionary<TEnum, ISpell> _logics = new();

        static LogicFactory()
        {
            _logics.Clear();

            var allLogicTypes = Assembly.GetAssembly(typeof(ISpell)).GetTypes()
                .Where(t => typeof(ISpell).IsAssignableFrom(t)
                            && !t.IsInterface
                            && !t.IsAbstract);

            foreach (var logicType in allLogicTypes)
            {
                var attribute = (LogicEnumTypeAttribute)Attribute.GetCustomAttribute(logicType, typeof(LogicEnumTypeAttribute));
                if (attribute != null)
                {
                    TEnum logicTypeEnum = (TEnum)Enum.Parse(typeof(TEnum), attribute.LogicType.ToString());
                    ISpell logic = (ISpell)Activator.CreateInstance(logicType);
                    _logics.Add(logicTypeEnum, logic);
                }
            }
        }

        public static ISpell GetLogicForType(TEnum logicType)
        {
            return _logics.TryGetValue(logicType, out var logic) ? logic : null;
        }
    }
}

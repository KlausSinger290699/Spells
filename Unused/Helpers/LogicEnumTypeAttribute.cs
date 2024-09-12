using System;

namespace SCD.Spells.Unused.Helpers
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class LogicEnumTypeAttribute : Attribute
    {
        public object LogicType { get; }

        public LogicEnumTypeAttribute(object logicType) => LogicType = logicType;
    }
}

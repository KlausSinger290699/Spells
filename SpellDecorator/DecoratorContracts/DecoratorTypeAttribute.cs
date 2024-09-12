using System;
using SCD.Spells.Core;

namespace SCD.Spells.SpellDecorator.DecoratorContracts
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class DecoratorTypeAttribute : Attribute
    {
        public DecoratorType DecoratorType { get; }
        public DecoratorTypeAttribute(DecoratorType decoratorType) => DecoratorType = decoratorType;
    }
}
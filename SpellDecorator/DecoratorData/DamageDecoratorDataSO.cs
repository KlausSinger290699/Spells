using UnityEngine;

namespace SCD.Spells.SpellDecorator.DecoratorData
{
    [CreateAssetMenu(fileName = "Damage_Decorator_Data", menuName = "SpellsV2/Decorator/Damage")]
    public class DamageDecoratorDataSO : DecoratorDataBaseSO
    {
        public float Damage = 5;
    }
}
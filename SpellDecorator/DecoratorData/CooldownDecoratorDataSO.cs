using UnityEngine;

namespace SCD.Spells.SpellDecorator.DecoratorData
{
    [CreateAssetMenu(fileName = "Cooldown_Decorator_Data", menuName = "SpellsV2/Decorator/Cooldown")]
    public class CooldownDecoratorDataSO : DecoratorDataBaseSO
    {
        public float CooldownReduction = 1;
    }
}
using System.Collections.Generic;
using SCD.Spells.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SCD.Spells.Unused.Tests
{
    [CreateAssetMenu(fileName = "DamageBuffTest", menuName = "SpellsV2/Decorator/DamageBuffTest")]
    public class DamageBuff : SerializedScriptableObject
    {
        [field: SerializeField] private Dictionary<CastingType, float[]> CastingTypeToDamageValues = new();
    }
}
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SCD.Spells.UpgradeSystem
{
    [CreateAssetMenu(fileName = "StatsList", menuName = "SpellsV2/Upgrade/StatsList")]
    public class StatsUpgradeDicSO : SerializedScriptableObject
    {
        public Dictionary<StatsUpgradeSO, bool> StatsUpgradeDic = new();
    }
}

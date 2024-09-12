using System.Collections.Generic;
using SCD.Spells.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SCD.Spells.UpgradeSystem
{
    [CreateAssetMenu(fileName = "Stats_Upgrade", menuName = "SpellsV2/Upgrade/StatsUpgrade")]
    public class StatsUpgradeSO : UpgradeBaseSO
    {
        [TabGroup("Spells To Upgrade", TextColor = "orange")]
        [Tooltip("The stats that this upgrade applies to.")]
        [SerializeField]
        private List<SpellStatsSO> _unitsToUpgrade = new();
        
        
        [field: TabGroup("Upgrade To Apply", TextColor = "yellow")]
        [field: Tooltip("Stats to upgrade.")]
        [field: SerializeField]  //Replace everything back to Stat Enum, if you want to go back.
        public Dictionary<SpellStats, float> UpgradeToApply { get; private set; } = new();

        
        [field: TabGroup("Upgrade To Apply", TextColor = "yellow")]
        [field: Tooltip("Percentage upgrade instead of amount.")]
        [field: SerializeField] 
        public bool IsPercentUpgrade { get; private set; }
        
        
        [Button]
        public override void DoUpgrade()
        {
            foreach (var unitToUpgrade in _unitsToUpgrade)
            {
                foreach (var upgrade in UpgradeToApply)
                {
                    unitToUpgrade.UnlockUpgrade(this);
                }
            }
            Debug.Log($"Upgrade {this.name} has been applied.");
        }
    }
}


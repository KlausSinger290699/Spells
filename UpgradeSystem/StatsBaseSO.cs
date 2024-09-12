using System;
using System.Collections.Generic;
using SCD.Spells.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SCD.Spells.UpgradeSystem
{
    [CreateAssetMenu(fileName = "Stats", menuName = "SpellsV2/Upgrade/Stats")]
    public class StatsBaseSO : SerializedScriptableObject
    {
        public event Action<StatsBaseSO, StatsUpgradeSO> OnUpgradeApplied;
        
        [field: SerializeField] public Dictionary<SpellStats, float> InstanceStats { get; private set; } = new(); //Use for temporary buffs
        [field: SerializeField] public Dictionary<SpellStats, float> Stats { get; private set; } = new();
        [ShowInInspector, ReadOnly] private List<StatsUpgradeSO> _appliedUpgrades = new();
        
        
        public void UnlockUpgrade(StatsUpgradeSO upgradeSo)
        {
            if (!_appliedUpgrades.Contains(upgradeSo))
            {
                _appliedUpgrades.Add(upgradeSo);
                OnUpgradeApplied?.Invoke(this, upgradeSo);
                Debug.Log($"Upgrade {upgradeSo.name} has been unlocked for {this.name}.");
            }
        }

        
        [Button]
        public float GetStat(SpellStats spellStats)
        {
            if (InstanceStats.TryGetValue(spellStats, out var instanceValue))
                return GetUpgradedValue(spellStats, instanceValue);
            else if (Stats.TryGetValue(spellStats, out float value))
                return GetUpgradedValue(spellStats, value);
            else
            {
                Debug.LogError($"No stat value found for {spellStats} on {this.name}");
                return 0;
            }
        }

        public int GetStatAsInt(SpellStats spellStats)
        {
            return (int)GetStat(spellStats);
        }
        
        private float GetUpgradedValue(SpellStats spellStats, float baseValue)
        {
            foreach (var upgrade in _appliedUpgrades)
            {
                if (!upgrade.UpgradeToApply.TryGetValue(spellStats, out float upgradeValue))
                    continue;

                if (upgrade.IsPercentUpgrade)
                    baseValue *= (upgradeValue / 100f) + 1f;
                else
                    baseValue += upgradeValue;
            }

            return baseValue;
        }
        
        
        [Button]
        public Dictionary<SpellStats, float> GetStats(bool onlyOriginal = false, bool onlyUpgraded = false)
        {
            if (onlyOriginal && onlyUpgraded)
            {
                onlyOriginal = false;
                onlyUpgraded = false;
            }
            
            Dictionary<SpellStats, float> resultStats = new Dictionary<SpellStats, float>();

            foreach (var stat in InstanceStats.Keys)
            {
                float originalValue = InstanceStats[stat];
                float upgradedValue = GetStat(stat);

                if (onlyOriginal)
                {
                    resultStats[stat] = originalValue;
                    continue;
                }

                if (onlyUpgraded && originalValue == upgradedValue)
                    continue;

                resultStats[stat] = upgradedValue;
            }

            foreach (var stat in Stats.Keys)
            {
                float originalValue = Stats[stat];
                float upgradedValue = GetStat(stat);

                if (onlyOriginal)
                {
                    resultStats[stat] = originalValue;
                    continue;
                }

                if (onlyUpgraded && originalValue == upgradedValue)
                    continue;

                resultStats[stat] = upgradedValue;
            }

            return resultStats;
        }

        
        [Button]
        public void ResetAppliedUpgrades() => _appliedUpgrades.Clear();
    }
}
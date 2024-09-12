using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SCD.Spells.UpgradeSystem
{
    public class StatsManager : MonoBehaviour
    {
        [SerializeField] private List<SpellStatsSO> _statsList;
        [SerializeField] private List<StatsUpgradeDicSO> _upgradeDics;
        private const string _statsPath = "Assets/_Main/Player/Scripts/Spells/UpgradeSystem/Resources/SpellStats";
        private const string _upgradesPath = "Assets/_Main/Player/Scripts/Spells/UpgradeSystem/Resources/Upgrades";

        private void OnApplicationQuit()
        {
            _statsList = HelperFunctions.GetScriptableObjects<SpellStatsSO>(_statsPath);
        
            foreach (var stat in _statsList)
            {
                stat.ResetAppliedUpgrades();
            }

            _upgradeDics = HelperFunctions.GetScriptableObjects<StatsUpgradeDicSO>(_upgradesPath);

            foreach (var upgrade in _upgradeDics)
            {        
                foreach (StatsUpgradeSO key in upgrade.StatsUpgradeDic.Keys.ToList())
                {
                    upgrade.StatsUpgradeDic[key] = false;
                }
            }
        }
    }
}
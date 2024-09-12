using UnityEngine;

namespace SCD.Spells.UpgradeSystem
{
    [CreateAssetMenu(fileName = "Stat", menuName = "SpellsV2/Upgrade/Stat")]
    public class StatSO : ScriptableObject
    {
        public string StatName;
        
        /*
        #region Validate
#if UNITY_EDITOR
        [OnInspectorGUI]
        private void OnInspectorGUI() => RenameAsset();
        
        private void RenameAsset()
        {
            string correctName = StatName + "_Stat";
            if (this.name != correctName)
            {
                string path = AssetDatabase.GetAssetPath(this);
                AssetDatabase.RenameAsset(path, correctName);
                AssetDatabase.Refresh();
                Debug.LogWarning($"Renamed asset to {correctName} to ensure consistency.");
            }
        }
#endif
        #endregion
        */
    }
}

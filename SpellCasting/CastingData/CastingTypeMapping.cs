using System.Collections.Generic;
using SCD.Spells.Core;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingData
{
    [CreateAssetMenu(fileName = nameof(CastingTypeMapping), menuName = "SpellsV2/Casting/Mapping")]
    public class CastingTypeMapping : SerializedScriptableObject
    {
        [field: SerializeField] public Dictionary<CastingType, ScriptableObject> Mappings = new();
        
        #region Validate
#if UNITY_EDITOR
        [OnInspectorGUI]
        private void OnInspectorGUI() => RenameAsset();
        
        private void RenameAsset()
        {
            string correctName = nameof(CastingTypeMapping);
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
    }
}
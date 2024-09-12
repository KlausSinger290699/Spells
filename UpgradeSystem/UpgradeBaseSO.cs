using Sirenix.OdinInspector;
using UnityEngine;

namespace SCD.Spells.UpgradeSystem
{
    public abstract class UpgradeBaseSO : SerializedScriptableObject
    {
        [field: TabGroup("Data", TextColor = "green")]
        [field: PreviewField]
        [field: SerializeField] public Sprite Sprite { get; private set; }        
        [field: TabGroup("Data", TextColor = "green")]
        [field: PreviewField]
        [field: SerializeField] public Sprite GraySprite { get; private set; }
        [field: TabGroup("Data", TextColor = "green")]
        [field: SerializeField] public string UpgradeName { get; private set; } 
        [field: TabGroup("Data", TextColor = "green")]
        [field: Multiline]
        [field: SerializeField] public string Description { get; private set; }
        
        
        public abstract void DoUpgrade();
    }
}




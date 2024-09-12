using SCD.Spells.Core;
using SCD.Spells.SpellCasting.CastingContracts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingData
{
    public abstract class CastingDataBaseSO : ScriptableObject, ICasting
    {
        [TabGroup(nameof(Data), TextColor = "green"), HideLabel]
        [SerializeField] 
        private CastingType _castingType;
        public virtual CastingType CastingType => _castingType;
        
        [TabGroup(nameof(Data), TextColor = "green"), HideLabel]
        [SerializeField] 
        private SpellData _data;
        [TabGroup(nameof(Stats), TextColor = "orange" ), HideLabel]
        [SerializeField] 
        private SpellStats _stats;

        public SpellData Data => _data; 
        public SpellStats Stats => _stats;

        [System.Serializable]
        public struct SpellData
        {
            public string SpellName;
            public Sprite SpellSprite;
            [Multiline]
            public string Description;
            public AudioClip CastSound;
            public GameObject SpellPrefab;
        }

        [System.Serializable]
        public struct SpellStats
        {
            public int Damage;
            public float Speed;
            public float LifeTime;
            public int ManaCost;
            public float Cooldown;
            public float CastTime;
        }
    }
}
using SCD.Spells.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SCD.Spells.UpgradeSystem
{
    [CreateAssetMenu(fileName = "Spell_Stats", menuName = "SpellsV2/Upgrade/SpellStats")]
    public class SpellStatsSO : StatsBaseSO
    {
        [System.Serializable]
        public struct s_Data
        {
            [PreviewField]
            public Sprite SpellSprite;
            [PreviewField]
            public Sprite SpellSpriteBW;
            public CastingType CastingType;
            public string SpellName;
            [Multiline]
            public string Description;
            public GameObject SpellPrefab;
        }

        [System.Serializable]
        public struct s_AnimationData
        {
            [Tooltip("Name of the animation")]
            public string Name;
            [Tooltip("Name of the Animation parameter for this animation that is used in the animator")]
            public string ParameterName;
            [Tooltip("Start Delay")]
            public float StartDelay;
            [Tooltip("Shorten the animation by putting in a negative number")]
            public float LessDuration;
        }

        public struct s_LiveData
        {
            public float Cooldown;
            public float RemainingCooldown;
            public bool CanCast;
        }

        [PropertyOrder(-1)] [TabGroup("Data", TextColor = "green")]
        [SerializeField]
        private s_Data _data;
        public s_Data Data => _data; 
        
        [PropertyOrder(-1)] [TabGroup("Animation Data", TextColor = "orange")]
        [SerializeField]
        private s_AnimationData _animationData;
        public s_AnimationData AnimationData => _animationData;

        
        [Tooltip("Modify the spell spawn position based on if it is a projectile or not")]
        [PropertyOrder(-1)] [TabGroup("Animation Data", TextColor = "orange")]
        public bool IsProjectile = true;
        [Tooltip("Modify where the Spell spawns by referencing an empty child GameObject of the Player")]
        [PropertyOrder(-1)] [TabGroup("Animation Data", TextColor = "orange")] [ShowIf(nameof(IsProjectile))]
        [SerializeField]
        public GameObject CastPoint1;
        [PropertyOrder(-1)] [TabGroup("Animation Data", TextColor = "orange")] [ShowIf(nameof(IsProjectile))]
        [SerializeField] 
        [Tooltip("Modify where the Spell spawns by referencing an empty child GameObject of the Player")]
        public GameObject CastPoint2;
        
        [Tooltip("Player Position")]
        [PropertyOrder(-1)] [TabGroup("Animation Data", TextColor = "orange")] [HideIf(nameof(IsProjectile))]
        [SerializeField]
        public GameObject PlayerPosition;
        [PropertyOrder(-1)] [TabGroup("Animation Data", TextColor = "orange")] [HideIf(nameof(IsProjectile))]
        [SerializeField]
        [Tooltip("Add some offset to the player Position")]
        public Vector3 Offset;
        [PropertyOrder(-1)] [TabGroup("Animation Data", TextColor = "orange")] [HideIf(nameof(IsProjectile))]
        [SerializeField] 
        [Tooltip("Special case")]
        public bool IsMeteorite;


        [PropertyOrder(-1)] [TabGroup("Live Data", TextColor = "yellow")]
        public s_LiveData LiveData;
    }
}


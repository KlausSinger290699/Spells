using SCD.Spells.Core;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingData
{
    [CreateAssetMenu(fileName = "Fireball_Casting_Data", menuName = "SpellsV2/Casting/Fireball")]
    public sealed class FireballCastingDataSO : CastingDataBaseSO
    {
        public override CastingType CastingType => CastingType.Fireball;
    }
}
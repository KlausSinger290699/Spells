using SCD.Spells.Core;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingData
{
    [CreateAssetMenu(fileName = "Lightning_Casting_Data", menuName = "SpellsV2/Casting/Lightning")]
    public sealed class LightningCastingDataSO : CastingDataBaseSO
    {
        public override CastingType CastingType => CastingType.Lightning;
    }
}
using SCD.Spells.Core;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingLogic
{
    public class LightningCastingLogic : CastingLogicBase
    {
        public LightningCastingLogic(Transform playerTransform) : base(CastingType.Lightning, playerTransform) { }

        public override void BeginCast()
        {
            base.BeginCast();
        }
    }
}
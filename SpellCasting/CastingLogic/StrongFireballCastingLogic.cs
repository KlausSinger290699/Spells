using SCD.Spells.Core;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingLogic
{
    public class StrongFireballCastingLogic : CastingLogicBase
    {
        public StrongFireballCastingLogic(Transform playerTransform) : base(CastingType.StrongFireball, playerTransform) { }
        
        public override void BeginCast()
        {
            base.BeginCast();
        }
    }
}
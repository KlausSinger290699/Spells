using SCD.Spells.Core;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingLogic
{
    public class WhirlwindCastingLogic : CastingLogicBase
    {
        public WhirlwindCastingLogic(Transform playerTransform) : base(CastingType.Whirlwind, playerTransform) { }
        
        public override void BeginCast()
        {
            base.BeginCast();
        }
    }
}
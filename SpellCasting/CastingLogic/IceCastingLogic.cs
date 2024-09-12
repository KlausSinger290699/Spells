using SCD.Spells.Core;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingLogic
{
    public class IceCastingLogic : CastingLogicBase
    {
        public IceCastingLogic(Transform playerTransform) : base(CastingType.Ice, playerTransform) { }
        
        public override void BeginCast()
        {
            base.BeginCast();
        }
    }
}
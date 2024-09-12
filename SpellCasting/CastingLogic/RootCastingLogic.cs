using SCD.Spells.Core;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingLogic
{
    public class RootCastingLogic : CastingLogicBase
    {
        public RootCastingLogic(Transform playerTransform) : base(CastingType.Root, playerTransform) { }
        
        public override void BeginCast()
        {
            base.BeginCast();
        }
    }
}
using SCD.Spells.Core;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingLogic
{
    public class MeteorCastingLogic : CastingLogicBase
    {
        public MeteorCastingLogic(Transform playerTransform) : base(CastingType.Meteor, playerTransform) { }
        
        public override void BeginCast()
        {
            base.BeginCast();
        }
    }
}
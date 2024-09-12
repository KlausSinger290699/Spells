using SCD.Spells.Core;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingLogic
{
    public class FireballCastingLogic : CastingLogicBase
    {
        public FireballCastingLogic(Transform playerTransform) : base(CastingType.Fireball, playerTransform) { }

        public override void BeginCast()
        {
            base.BeginCast();
        }
    }
}
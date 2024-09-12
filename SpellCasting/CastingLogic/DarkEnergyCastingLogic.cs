using SCD.Spells.Core;
using UnityEngine;

namespace SCD.Spells.SpellCasting.CastingLogic
{
    public class DarkEnergyCastingLogic : CastingLogicBase
    {
        public DarkEnergyCastingLogic(Transform playerTransform) : base(CastingType.DarkEnergy, playerTransform) { }
        
        public override void BeginCast()
        {
            base.BeginCast();
        }
    }
}
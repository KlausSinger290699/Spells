using System.Collections;
using System.Collections.Generic;
using SCD.Spells.Core;
using SCD.Spells.UpgradeSystem;
using UnityEngine;

namespace SCD.Spells
{
    public class AssignCastPointTransform : MonoBehaviour
    {
        [SerializeField] private List<SpellStatsSO> _spellStats;
        [SerializeField] private GameObject _castPoint1;
        [SerializeField] private GameObject _castPoint2;

        [SerializeField] private GameObject _player;

        //Check for IsProjectile in a foreach instead
        void Start() 
        {
            foreach (SpellStatsSO stat in _spellStats)
            {
                switch (stat.Data.CastingType)
                {
                    case CastingType.DarkEnergy:
                    {
                        stat.CastPoint1 = _castPoint1.transform.Find("mixamorig:LeftHand").gameObject;
                        stat.CastPoint2 = _castPoint2.transform.Find("mixamorig:RightHand").gameObject;
                        break;
                    }
                    case CastingType.Fireball:
                    {
                        stat.CastPoint1 = _castPoint1.transform.Find("mixamorig:LeftHand").gameObject;
                        stat.CastPoint2 = _castPoint2.transform.Find("mixamorig:RightHand").gameObject;
                        break;
                    }
                    case CastingType.Ice:
                    {
                        stat.PlayerPosition = _player;
                        break;
                    }
                    case CastingType.Lightning:
                    {
                        stat.CastPoint1 = _castPoint1.transform.Find("mixamorig:LeftHand").gameObject;
                        stat.CastPoint2 = _castPoint2.transform.Find("mixamorig:RightHand").gameObject;
                        break;
                    }
                    case CastingType.Meteor:
                    {
                        stat.PlayerPosition = _player;
                        break;
                    }
                    case CastingType.Root:
                    {
                        stat.PlayerPosition = _player;
                        break;
                    }
                    case CastingType.StrongFireball:
                    {
                        stat.PlayerPosition = _player;
                        break;
                    }
                    case CastingType.Whirlwind:
                    {
                        stat.PlayerPosition = _player;
                        break;
                    }
                }
            }
        }
    }
}

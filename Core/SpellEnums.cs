using UnityEngine;

namespace SCD.Spells.Core
{
    public enum CastingType
    {
        Fireball = 0,
        Lightning = 1,
        Whirlwind = 2,
        Root = 3,
        Ice = 4,
        StrongFireball = 5,
        Meteor = 6,
        DarkEnergy = 7,
    }

    public enum DecoratorType
    {
        Damage = 0,
        Cooldown = 1,
        Decorator2 = 2,
        Decorator3 = 3,
    }

    public enum CompositeType
    {
        
    }

    public enum SpellData
    {
        SpellName = 0,
        SpellSprite = 1,
        Description = 2,
        CastSound = 3,
        SpellPrefab = 4,
    }
    
    public enum SpellStats
    {
        Damage = 0,
        ManaCost = 3,
        Cooldown = 4,
        CastTime = 5,
        
        //Ice
        EnemySpeedReductionPercentage,
        SpeedReductionDuration,
        
        //Meteor, Root Spell (Damage per second)
        DamagePerSecond,
        DamageDuration,
        
        //Fireball, Strong Fireball
        ExplosionRadius,
        
        //Whirlwind, Root Spell (Root Duration)
        PushbackForce,
        Radius,
        RootDuration,
    }
}
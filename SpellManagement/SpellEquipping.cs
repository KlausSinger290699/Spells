using System;
using System.Collections.Generic;
using MyExternalTools.SOReference;
using SCD.Spells.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SCD.Spells.SpellManagement
{
    public class SpellEquipping : RegisterTargetScriptBase
    {
        public static event Action<CastingType, int> OnSpellEquippedAtStart;

        private enum InitializationType
        {
            None,
            OneSpell,
            AllSpells
        }

        [SerializeField]
        private InitializationType _initializationType = InitializationType.OneSpell;

        [ShowIf(nameof(IsOneSpellInitialization))]
        [SerializeField]
        private CastingType _spellToEquip = CastingType.Fireball;

        public List<CastingType> EquippedSpells { get; private set; } = new();

        private SpellManager _spellManager;
        private int _slotCounter;

        private void Awake() => _spellManager = GetComponent<SpellManager>();
        
        private void Start()
        {
            switch (_initializationType)
            {
                case InitializationType.OneSpell:
                    EquipSpell(_spellToEquip);
                    OnSpellEquippedAtStart?.Invoke(_spellToEquip, _slotCounter);
                    break;
                case InitializationType.AllSpells:
                    EquipAllSpells();
                    break; 
            }
        }

        public void EquipSpell(CastingType castingType)
        {
            _spellManager.EquipSpell(_slotCounter, castingType);
            EquippedSpells.Add(castingType);
            _slotCounter++;
        }

        private void EquipAllSpells()
        {
            foreach (CastingType castingType in Enum.GetValues(typeof(CastingType)))
            {
                EquipSpell(castingType);
                OnSpellEquippedAtStart?.Invoke(castingType, _slotCounter);
            }
        }

        private bool IsOneSpellInitialization() => _initializationType == InitializationType.OneSpell;
    }
}
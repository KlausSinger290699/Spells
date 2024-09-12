using SCD.Spells.SpellCasting.CastingContracts;
using SCD.Spells.SpellCasting.CastingLogic;
using UnityEngine;

namespace SCD.Spells.Core
{
    public partial class SpellManager : MonoBehaviour
    {
        private readonly ISpell[] _equippedSpells = new ISpell[4];
        private float _mana;
        
        private void Awake() => CastingLogicFactory.Initialize(transform);
        
        public void UpdateMana(float mana) => _mana = mana;
        
        private void Update()
        {
            foreach (var spell in _equippedSpells)
            {
                if (spell is ITick tick)
                    tick?.Tick(_mana);
            }
        }
        
        public void CastSpell(int slot)
        {
            if (slot >= 0 && slot < _equippedSpells.Length)
                _equippedSpells[slot]?.BeginCast();
            else
                Debug.LogWarning("Invalid slot number for casting spell");
        }
        
        public void EquipSpell(int slot, CastingType castingType)
        {
            if (slot >= 0 && slot < _equippedSpells.Length)
            {
                if (_equippedSpells[slot] != null)
                {
                    Debug.LogWarning("A spell is already equipped in this slot. Unequip it first.");
                    return;
                }

                _equippedSpells[slot] = CastingLogicFactory.GetSpellForType(castingType);
            }
            else
            {
                Debug.LogWarning("Invalid slot number for equipping spell");
            }
        }
        
        public void SwapSpells(int slot1, int slot2)
        {
            if (slot1 >= 0 && slot1 < _equippedSpells.Length && slot2 >= 0 && slot2 < _equippedSpells.Length)
                (_equippedSpells[slot1], _equippedSpells[slot2]) = (_equippedSpells[slot2], _equippedSpells[slot1]);
            else
                Debug.LogWarning("Invalid slot numbers for swapping spells");
        }
    }
}
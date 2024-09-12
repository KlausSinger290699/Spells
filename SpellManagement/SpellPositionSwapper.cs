using SCD.Spells.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SCD.Spells.SpellManagement
{
    public class SpellPositionSwapper : MonoBehaviour
    {
        private SpellManager _spellManager;

        
        private void Awake() => _spellManager = GetComponent<SpellManager>();


        #region Tests
        [SerializeField] private bool _hideTests = true;
        
        [ButtonGroup("Swap Spells"), HideIf(nameof(_hideTests))] 
        private void SwapSpell0With1() => _spellManager.SwapSpells(0, 1);
        [ButtonGroup("Swap Spells"), HideIf(nameof(_hideTests))] 
        private void SwapSpell1With2() => _spellManager.SwapSpells(1, 2);
        [ButtonGroup("Swap Spells"), HideIf(nameof(_hideTests))] 
        private void SwapSpell2With3() => _spellManager.SwapSpells(2, 3);
        [ButtonGroup("Swap Spells"), HideIf(nameof(_hideTests))] 
        private void SwapSpell3With0() => _spellManager.SwapSpells(3, 0);
        
        [Button, HideIf(nameof(_hideTests))] 
        private void SwapSpells(int slot1, int slot2) => _spellManager.SwapSpells(slot1, slot2);
        #endregion
    }
}
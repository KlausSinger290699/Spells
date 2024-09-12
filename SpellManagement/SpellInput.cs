using System;
using SCD.Spells.Core;
using UnityEngine;

namespace SCD.Spells.SpellManagement
{
    public class SpellInput : MonoBehaviour
    {
        private SpellManager _spellManager;
        private bool _isAbsorbing;

        private void Awake() => _spellManager = GetComponent<SpellManager>();
        
        public void HandleOnSoulAbsorptionActive(bool isAbsorbing)
        {
            _isAbsorbing = !_isAbsorbing;
            Debug.Log($"Is Absorbing: {_isAbsorbing}");
        }

        private void Update()
        {
            if(_isAbsorbing)
                return;
                
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _spellManager.CastSpell(0);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                _spellManager.CastSpell(1);

            if (Input.GetKeyDown(KeyCode.Alpha3))
                _spellManager.CastSpell(2);

            if (Input.GetKeyDown(KeyCode.Alpha4))
                _spellManager.CastSpell(3);
        }
    }
}
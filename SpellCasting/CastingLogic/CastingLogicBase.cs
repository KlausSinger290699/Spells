using System;
using System.Collections;
using SCD.Spells.Core;
using SCD.Spells.Helpers;
using SCD.Spells.SpellCasting.CastingContracts;
using SCD.Spells.SpellCasting.CastingData;
using SCD.Spells.UpgradeSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SCD.Spells.SpellCasting.CastingLogic
{
    public abstract class CastingLogicBase : ISpell, ICasting, ITick
    {
        #region Initialization
        public CastingType CastingType { get; }

        public static event Action<float> OnCastSpell;
        
        private readonly SpellStatsSO _castingData;
        private readonly Transform _playerTransform;
        
        private static float _castTimer;
        private float _cooldownTimer;
        private bool _canCast;
        private bool _isCasting;
        
        public static bool HasCastTimeElapsed => _castTimer <= 0f;
        public bool IsReadyToCast => _cooldownTimer <= 0f && HasCastTimeElapsed;
        public float CooldownTimer
        {
            get => _cooldownTimer;
            private set => _cooldownTimer = Mathf.Max(value - Time.deltaTime, 0f);
        }
        public static float CastTimer
        {
            get => _castTimer;
            private set => _castTimer = Mathf.Max(value - Time.deltaTime, 0f);
        }

        private GameObject _instance;
        
        protected CastingLogicBase(CastingType castingType, Transform playerTransform)
        {
            CastingType = castingType;
            _playerTransform = playerTransform;
            
            _castingData = (SpellStatsSO)CastingDataFactory.GetSpellDataForType(CastingType);
        }
        #endregion

        #region Methods
        public virtual void BeginCast()
        {
            if (!_canCast)
                return;
            
            if (!IsReadyToCast)
                return;

            if (_castingData == null)
            {
                Debug.LogError("You forgot to assign the Casting Data ScriptableObject in CastingTypeMapping");
                return;
            }
            //Debug.Log($"Spell casted from base class: {_castingData.GetType().Name}");
            
            _cooldownTimer = _castingData.GetStat(SpellStats.Cooldown);
            
            _playerTransform.gameObject.GetComponent<MonoBehaviour>().StartCoroutine(
                AnimationStaticMethods.CO_PlayAnimation(_playerTransform.GetComponent<Animator>(), 
                    _castingData.AnimationData.ParameterName,
                    _castingData.AnimationData.Name,
                    _castingData.AnimationData.LessDuration));

            _playerTransform.gameObject.GetComponent<MonoBehaviour>().StartCoroutine(
                DelayedInstantiate());
        }

        private IEnumerator DelayedInstantiate()
        {
            _castTimer = _castingData.GetStat(SpellStats.CastTime);
            OnCastSpell?.Invoke(_castingData.GetStat(SpellStats.ManaCost));
            _castingData.LiveData.Cooldown = _castingData.GetStat(SpellStats.Cooldown);
            _isCasting = true;
            
            yield return new WaitForSeconds(_castingData.AnimationData.StartDelay);

            // This is the instantiation logic you had in BeginCast
            if (_castingData.IsProjectile && !_castingData.IsMeteorite)
            {
                Vector3 midpoint = (_castingData.CastPoint1.transform.position + _castingData.CastPoint2.transform.position) / 2.0f;
                _instance = Object.Instantiate(_castingData.Data.SpellPrefab, midpoint, _playerTransform.rotation);
            }
            else if (!_castingData.IsProjectile && !_castingData.IsMeteorite)
            {
                Vector3 extraHeight = _castingData.PlayerPosition.transform.position + _castingData.Offset;
                _instance = Object.Instantiate(_castingData.Data.SpellPrefab, extraHeight, _playerTransform.rotation);
            }
            else if (_castingData.IsMeteorite)
            {
                Vector3 extraHeight = _castingData.PlayerPosition.transform.position + _castingData.Offset;
                _instance = Object.Instantiate(_castingData.Data.SpellPrefab, extraHeight, Quaternion.identity);
            }
        }
        
        public virtual void Tick(float mana)
        {
            if (mana < _castingData.GetStat(SpellStats.ManaCost))
                _canCast = false;
            else
                _canCast = true;

            CooldownTimer = CooldownTimer;
            CastTimer = CastTimer;
            _castingData.LiveData.CanCast = IsReadyToCast;
            _castingData.LiveData.RemainingCooldown = CooldownTimer;

            if (_isCasting)
            {
                if (_castingData.IsProjectile && !_castingData.IsMeteorite && _instance != null)
                {
                    Vector3 midpoint = (_castingData.CastPoint1.transform.position +
                                        _castingData.CastPoint2.transform.position) / 2.0f;
                    _instance.transform.position = midpoint;
                    _instance.transform.rotation = _playerTransform.rotation;
                }
                else if (!_castingData.IsProjectile && !_castingData.IsMeteorite && _instance != null)
                {
                    Vector3 extraHeight = _castingData.PlayerPosition.transform.position + _castingData.Offset;
                    _instance.transform.position = extraHeight;
                    _instance.transform.rotation = _playerTransform.rotation;
                }
                else if (_castingData.IsMeteorite && _instance != null)
                {
                    Vector3 extraHeight = _castingData.PlayerPosition.transform.position + _castingData.Offset;
                    _instance.transform.position = extraHeight;
                    _instance.transform.rotation = Quaternion.identity;
                }

                if (HasCastTimeElapsed)
                    Cast();
            }
        }
        
        private void Cast()
        {
            _isCasting = false;
        }
        #endregion
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Base.Level;
using Core.Characters.Player;
using Core.Characters.Player.Wallet;
using Core.Components.Base;
using Core.Components.Wallet;
using DG.Tweening;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Environment.TrainingZone.Simulator
{
    public class PumperWallet : SaveLoadComponent
    {
        [SerializeField] private Wallet _buyerWallet;
        [SerializeField] private DetectorWalletPlayer _detectorWallet;
        [SerializeField] private float _currenPumping = 0.1f;
        [SerializeField] private Transform model;
        private WalletPlayer _playerWallet;
        private float _startPumping;
        private Tween _tween;
        public event Action<int> OnUpdateCount;
        public event Action OnBuy;
        public bool IsBuy => Load() == 1;

        #region Enable / Disable
        private void OnEnable()
        {
            _detectorWallet.OnEnterWallet += PumpingWallet;
            _detectorWallet.OnExit += StopPumping;
        }

        private void OnDisable()
        {
            _detectorWallet.OnEnterWallet -= PumpingWallet;
            _detectorWallet.OnExit -= StopPumping;
        }
        #endregion

        private void Start()
        {
            var count = Load();
            if (count > 0)
            {
                _buyerWallet.Set(count);
            }
        }

        public void Activate()
        {
            model.Activate();
        }

        public void Deactivate()
        {
            model.Deactivate();
        }
        private void PumpingWallet(WalletPlayer wallet)
        {
            _playerWallet = wallet;
            _tween = DOTween.To(() => _currenPumping, v => _currenPumping = v, 0, 0.5f);
            StartCoroutine(Pumping());
        }

        private IEnumerator Pumping()
        {
            var spendCount = 30;
            while (_playerWallet && _playerWallet.HasCanSpend())
            {
                _buyerWallet.Spend(_playerWallet.HasCanSpend(spendCount) ? spendCount : 1);
                _playerWallet.Spend(_playerWallet.HasCanSpend(spendCount) ? spendCount : 1);
                
                UpdateCount();
                if (_buyerWallet.CurrentCount <= 0)
                {
                    Buy();
                    break;
                }
                yield return new WaitForSeconds(_currenPumping);
            }
        }

        private void Buy()
        {
            OnBuy?.Invoke();
            Save(1);
        }

        private void StopPumping()
        {
            _currenPumping = _startPumping;
            _playerWallet = null;
            _tween.Kill();
        }
        private void UpdateCount()
        {
            Save(_buyerWallet.CurrentCount);
            OnUpdateCount?.Invoke(_buyerWallet.CurrentCount);
        }
        
    }
}
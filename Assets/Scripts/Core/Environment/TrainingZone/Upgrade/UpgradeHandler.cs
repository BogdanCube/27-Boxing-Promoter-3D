using System;
using System.Collections.Generic;
using Core.Characters.Player.Wallet;
using Core.Components.Wallet;
using UnityEngine;

namespace Core.Environment.TrainingZone.Upgrade
{
    public class UpgradeHandler : MonoBehaviour
    {
        [SerializeField] private DetectorWalletPlayer _detector;
        [SerializeField] private LoaderUpgrade _loaderUpgrade;
        [SerializeField] private List<UpgraderLevel> _upgraderLevels;

        #region Enable / Disable
        private void OnEnable()
        {
            _detector.OnEnterWallet += Load;
            _detector.OnExit += Deload;
        }
        private void OnDisable()
        {
            _detector.OnEnterWallet -= Load;
            _detector.OnExit -= Deload;
        }
        #endregion
        
        private void Load(WalletPlayer wallet)
        {
            _loaderUpgrade.Load(_upgraderLevels,wallet);
        }
        private void Deload()
        {
            _loaderUpgrade.Deload();
        }
    }
}
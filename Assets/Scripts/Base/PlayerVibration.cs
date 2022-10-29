using Core.Characters.Player;
using Core.Characters.Player.Wallet;
using Core.Components.Detachment;
using Core.Components.Wallet;
using MoreMountains.NiceVibrations;
using UnityEngine;

namespace Base
{
    public class PlayerVibration : MonoBehaviour
    {
        [SerializeField] private Player _player;
        private Detachment _detachment;
        private WalletPlayer _wallet;
        #region Enable / Disable
        private void OnEnable()
        {
            _detachment = _player.Detachment;
            _wallet = _player.Wallet;
            _detachment.OnUpdateCount += UpdateDetachment;
            _wallet.OnUpdateCount += UpdateWallet;
        }
        private void OnDisable()
        {
            _detachment.OnUpdateCount -= UpdateDetachment;
            _wallet.OnUpdateCount -= UpdateWallet;
        }
        #endregion

        #region Vibration

        private void UpdateDetachment(int currentCount,int maxCount)
        {
            MMVibrationManager.Haptic (HapticTypes.HeavyImpact);
        }
        private void UpdateWallet(int count)
        {
            MMVibrationManager.Haptic (HapticTypes.Selection);
        }

        #endregion
    }
}
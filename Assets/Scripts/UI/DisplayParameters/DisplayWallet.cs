using Core.Characters.Player.Wallet;
using Core.Components.Wallet;
using DG.Tweening;
using NaughtyAttributes;
using NTC.Global.Pool;
using TMPro;
using UnityEngine;

namespace UI.DisplayParameters
{
    public class DisplayWallet : MonoBehaviour
    {
        [InterfaceType(typeof(Wallet))][SerializeField] private Object _wallet;
        [SerializeField] private TextMeshProUGUI _text;

        private IWallet Wallet => (IWallet)_wallet;
        #region Enable/Disable
        private void OnEnable()
        {
            Wallet.OnUpdateCount += UpdateText;
        }
        private void OnDisable()
        {
            Wallet.OnUpdateCount -= UpdateText;
        }
        #endregion
        
        private void UpdateText(int count = 0)
        {
            _text.text = $"{count}";
        }
    }
}
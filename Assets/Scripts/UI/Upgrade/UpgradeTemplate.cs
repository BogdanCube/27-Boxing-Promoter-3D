using System;
using Core.Characters.Player.Wallet;
using Core.Components.Wallet;
using Core.Environment.TrainingZone.Upgrade;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Upgrade
{
    public class UpgradeTemplate : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private TextMeshProUGUI _upgradeText;
        [SerializeField] private Button _button;
        private UnityAction BuyAction;

        private void Start()
        {
            _button.onClick.AddListener(() => BuyAction?.Invoke());
        }

        public void Load(UpgraderLevel upgraderLevel, WalletPlayer wallet, Action Reload)
        {
            _text.text = upgraderLevel.Title;
            _icon.sprite = upgraderLevel.Icon;

            _priceText.text = IsNotMax() ? upgraderLevel.Price.ToString() : "MAX";
            _priceText.color = IsNotMax() ? IsHaveMoney() ? Color.green : Color.red : Color.white;
            _upgradeText.text = IsNotMax() ? upgraderLevel.Description : string.Empty;

            BuyAction = Buy;
            
            bool IsNotMax()
            {
                return upgraderLevel.IsMaxLevel == false;
            }
            bool IsHaveMoney()
            {
               return wallet.HasCanSpend(upgraderLevel.Price);
            }
            void Buy()
            {
                if (IsHaveMoney() && IsNotMax())
                {
                    wallet.Spend(upgraderLevel.Price);
                    upgraderLevel.LevelUps();
                    BuyAction = null;
                    Reload.Invoke();
                }
            }
        }
    }
}
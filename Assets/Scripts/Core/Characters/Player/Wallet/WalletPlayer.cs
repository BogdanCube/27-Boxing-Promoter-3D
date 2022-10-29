using System;
using Core.Components.Base;
using Core.Environment.UpgraderPlayer;
using UnityEngine;

namespace Core.Characters.Player.Wallet
{
    public class WalletPlayer : SaveLoadComponent,IUpgrader,IWallet
    {
        [SerializeField] private int _count;
        [SerializeField] private int _addMoney = 5;
        public event Action<int> OnUpdateCount;
        public event Action OnAdd;
        public bool HasCanSpend(int count = 1) => _count - count >= 0;

        private void Start()
        {
            _count = Load();
            UpdateCount();
        }
        public void Add(int count = 1)
        {
            _count += count;
            OnAdd?.Invoke();
            UpdateCount();
        }
        public void Spend(int count = 1)
        {
            _count -= count;
            UpdateCount();
        }
        public void AddMoney()
        {
            Add(_addMoney);
        }
        public void SetUpgrades(int addMoney)
        {
            _addMoney = addMoney;
        }
        private void UpdateCount()
        {
            OnUpdateCount?.Invoke(_count);
            Save(_count);
        }
    }
}
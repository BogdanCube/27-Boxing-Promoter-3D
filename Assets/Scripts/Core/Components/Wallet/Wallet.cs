using System;
using System.Collections;
using Core.Characters.Player.Wallet;
using Core.Components.Base;
using UnityEngine;

namespace Core.Components.Wallet
{
    public class Wallet : MonoBehaviour,IWallet
    {
        [SerializeField] private int _count;
        public event Action<int> OnUpdateCount;
        public int CurrentCount => _count;

        private void Start()
        {
            OnUpdateCount?.Invoke(_count);
        }

        public void Spend(int count = 1)
        {
            _count -= count;
            OnUpdateCount?.Invoke(_count);
        }
        public void Set(int count)
        {
            _count = count;
            OnUpdateCount?.Invoke(_count);
        }
    }
}
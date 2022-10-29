using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Characters.Player;
using Core.Characters.Player.Wallet;
using Core.Components.Detachment.Formation;
using Core.Components.Wallet;
using DG.Tweening;
using NaughtyAttributes;
using NTC.Global.Pool;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Environment.Ring.CollectorMoney
{
    public class CollectorMoney : MonoBehaviour
    {
        [SerializeField] private GeneratorPoint _generator;
        [SerializeField] private Transform _pool;
        [SerializeField] private Money _prefab;
        private List<Money> _monies = new();
        private bool _isStop;
        public bool HasCan => _monies.Count + 1 < _generator.LimitMoney && _isStop == false;
        [Button]
        private void Spawn()
        {
            if(_generator.LimitMoney <= 0) return;
            
            var money = NightPool.Spawn(_prefab, _pool);
            _monies.Add(money);
            money.SetPosition(GetPosition());

        }
        public void Add(Money money)
        {
            _monies.Add(money);
            money.MoveTo(_pool, GetPosition());
        }
        private Vector3 GetPosition()
        {
            return _generator.GetPosition(_monies.Count);
        }

        private async void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out WalletPlayer wallet))
            {
                var tempMonies = _monies;
                _monies = new List<Money>();
                for (int i = tempMonies.Count - 1; i >= 0; i--)
                {
                    await Task.Delay(TimeSpan.FromSeconds(0.02f));
                    wallet.AddMoney();
                    NightPool.Despawn(tempMonies[i]);
                }
            }
        }
    }
}
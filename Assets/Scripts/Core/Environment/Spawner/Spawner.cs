using System;
using System.Threading.Tasks;
using Core.Characters.Fighter;
using Core.Environment.UpgraderPlayer;
using Core.Environment.Zone;
using Core.Environment.Zone.Data;
using DG.Tweening;
using NTC.Global.Pool;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Environment.Spawner
{
    public class Spawner : MonoBehaviour,IUpgrader
    {
        [SerializeField] private float _timeSpawn;
        [SerializeField] private PullZone _pullZone;
        [SerializeField] private Fighter _prefab;
        [SerializeField] private int _countSpawn = 2;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Bus _bus;
        private bool _isSpawning;
        public Func<float,Tween> OnSpawn;
        
        #region Enable / Disable
        private void OnEnable()
        {
            _bus.OnArrived += Spawn;
            _pullZone.OnPull += StartSpawn;
        }

        private void OnDisable()
        {
            _bus.OnArrived -= Spawn;
            _pullZone.OnPull -= StartSpawn;
        }
        #endregion
        
        private async void Spawn()
        {
            _bus.EndMove();

            if (_pullZone.IsMaxCount) return;
            for (var i = 0; i < _countSpawn; i++)
            {
                var fighter = NightPool.Spawn(_prefab, _spawnPoint.position);
                _pullZone.Push(fighter);
                await Task.Delay(TimeSpan.FromSeconds(0.5f));
            }

            StartSpawn();
        }

        private void StartSpawn()
        {
            if (_pullZone.IsMaxCount == false && _isSpawning == false)
            {
                _isSpawning = true;
                OnSpawn?.Invoke(_timeSpawn).OnComplete(() =>
                {
                    _isSpawning = false;
                    _bus.StartMove();
                });
            }
        }

        public void SetUpgrades(int timeSpawn)
        {
            _timeSpawn = timeSpawn;
        }
    }
}
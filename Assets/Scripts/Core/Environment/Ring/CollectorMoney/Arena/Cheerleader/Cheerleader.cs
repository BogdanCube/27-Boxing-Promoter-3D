using System;
using System.Threading.Tasks;
using Core.Components.Wallet;
using NaughtyAttributes;
using NTC.Global.Pool;
using Toolkit.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Environment.Ring.CollectorMoney.Arena.Cheerleader
{
    public class Cheerleader : MonoBehaviour
    {
        [SerializeField] private Vector2Int _defaultGive = new(0,1);
        [SerializeField] private Vector2Int _winGive = new(1,4);
        [SerializeField] private Animator _animator;
        [SerializeField] private float _timeUp;
        [SerializeField] private float _timeDown;
        [SerializeField] private Arena _arena;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Money _prefab;
        private RingFighting _ring;
        private CollectorMoney _collector;
        private readonly int _nameIdCheering = Animator.StringToHash("Cheering");

        #region Enable / Disable
        private void OnEnable()
        {
            //transform.LookAt(_arena.transform);
            _ring = _arena.Ring;
            _collector = _arena.Collector;
            _ring.OnAttack += GiveMoney;
            _ring.OnWin += GiveManyMoney;
        }

        private void OnDisable()
        {
            _ring.OnAttack -= GiveMoney;
            _ring.OnWin -= GiveManyMoney;
        }
        #endregion
        private void GiveManyMoney()
        {
            Give(_winGive.RandomRange());
        }
        private void GiveMoney()
        {
            Give(_defaultGive.RandomRange());
        }
        [Button]
        private async Task Give(int count = 1)
        {
            if(_collector.HasCan == false) return;
            
            await Task.Delay(TimeSpan.FromSeconds(Random.Range(0f,1f)));
            _animator.SetTrigger(_nameIdCheering);
            
            await Task.Delay(TimeSpan.FromSeconds(0.5f));
            for (int i = 0; i < count; i++)
            {
                var money = NightPool.Spawn(_prefab, _spawnPoint.position);
                money.Init(_timeUp,_timeDown);
                _collector.Add(money);
                await Task.Delay(TimeSpan.FromSeconds(0.2f));
            }
        }
    }
}
using System;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Characters.Fighter.Health
{
    public class HealthComponent : MonoBehaviour
    {
        [ShowNonSerializedField] private int _currentCount = 1;
        [ShowNonSerializedField] private int _maxCount = 1;
        public event Action<int,int> OnUpdateCount;
        public event Action OnHit;
        public event Action OnDeath;
        public bool IsDeath { get; private set; }
        public int Damage { get; private set; }

        public void Load(int health, int damage)
        {
            _maxCount = health;
            Damage = damage;
            _currentCount = _maxCount;
        }
        
        [Button]
        public void Heal(int count = 1)
        {
            _currentCount += count;
            if (_currentCount > _maxCount)
            {
                _currentCount = _maxCount;
            }

            UpdateCount();
        }
        [Button]
        public void Hit(int damage = 1)
        {
            _currentCount -= damage;
            if (_currentCount <= 0)
            {
                _currentCount = 0;
                IsDeath = true;
                OnDeath?.Invoke();
            }
            UpdateCount();
        }

        [Button]
        public void Death()
        {
            Hit(_maxCount);
        }
        private void UpdateCount()
        {
            OnUpdateCount?.Invoke(_currentCount,_maxCount);
        }
    }
}
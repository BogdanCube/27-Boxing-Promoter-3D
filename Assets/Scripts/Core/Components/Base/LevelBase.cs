using NaughtyAttributes;
using UnityEngine;
using System;

namespace Core.Components.Base
{
    public abstract class LevelBase : SaveLoadComponent
    {
        private int _level;
        public event Action OnUpdate;
        [ShowNativeProperty]protected int CurrentLevel => _level;
        protected abstract int MaxLevel { get; }
        public abstract bool IsMaxLevel { get; }
        public abstract int Price { get; }
        public abstract string Description { get; }
        private void Awake()
        {
            _level = Load();
             LevelUpAction();
             OnUpdate?.Invoke();
        }
        private void Start()
        {            
            LevelUpAction();
            OnUpdate?.Invoke();
        }

        [Button]
        public void LevelUp()
        {
            if (_level + 1 < MaxLevel)
            {
                _level++;
                Save(_level);
                OnUpdate?.Invoke();
                LevelUpAction();
            }
        }
        protected virtual void LevelUpAction() { }

        protected string ConvertUpgrade(float currentValue, float nextValue)
        {
            return $"{currentValue} -> {nextValue}";
        }
    }
}
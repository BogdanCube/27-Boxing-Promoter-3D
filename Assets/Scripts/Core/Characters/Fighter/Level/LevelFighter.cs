using System;
using Core.Characters.Fighter.Health;
using Core.Characters.Fighter.Level.Data;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

namespace Core.Characters.Fighter.Level
{
    public class LevelFighter : MonoBehaviour
    {
        [SerializeField] private AnimationFighter _animation;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] [Expandable] private DataLevel _dataLevel;
        [SerializeField] private ScalerFat _scaler;
        private int _level;
        public event Action<int, Color> OnUpdateBar;
        public event Func<float, Tween> OnStartUpgrading;
        [ShowNativeProperty] public int CurrentLevel => _level;
        [ShowNativeProperty] public bool IsTraining { get; private set; }
        
        public async void Load(int level)
        {
            _level = level;
            var currentTemplate = _dataLevel.Templates[_level];
            _scaler.SetFat(currentTemplate.FatAmount);

            _healthComponent.Load(currentTemplate.Health, currentTemplate.Damage);
            OnUpdateBar?.Invoke(_level, currentTemplate.Color);
           
            await Task.Delay(TimeSpan.FromSeconds(3));
            _animation.SetTrainingClip(currentTemplate.TrainingClip);
        }

        [Button]
        public void LevelUp()
        {
            IsTraining = false;
            _level++;
            Load(_level);
        }

        public Tween StartUpgrading(float duration)
        {
            IsTraining = true;
            return OnStartUpgrading?.Invoke(duration);
        }
    }
}
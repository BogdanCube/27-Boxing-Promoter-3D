using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Components.Base;
using Core.Environment.Zone.PushZone;
using NaughtyAttributes;
using UnityEngine;

namespace Base.Level
{
    public class LoaderLevel : SaveLoadComponent
    {
        [SerializeField] private PushZoneBoss _zoneBoss;
        [SerializeField] private PushZoneEnemy _zoneEnemy;
        [SerializeField] private List<int> _bossLevels;
        [SerializeField] private List<Level> _levels;
        [SerializeField] private SelectorCamera _selector;
        private int _number;
        public event Action OnLevelUp;
        [ShowNativeProperty]public int Number => _number;
        #region Enable / Disable
        private void OnEnable()
        {
            _zoneBoss.OnBossDeath += LevelUp;
        }
        private void OnDisable()
        {
            _zoneBoss.OnBossDeath -= LevelUp;
        }
        #endregion
        private void Awake()
        {
            if (HasKey)
            {
                _number = Load();
                _zoneEnemy.Init(_number);
            }
            else
            {
                _zoneEnemy.SpawnMax(_number);
            }
            Save(_number);

            for (int i = 0; i <= _number; i++)
            {
                _levels[i].Open();
            }
            SpawnBoss();
        }

        private async void LevelUp()
        {
            if (_number + 1 < _levels.Count)
            {
                _number++;
                await ShowNewLevel();
                Save(_number);
            }
            OnLevelUp?.Invoke();
            Spawn();

            async Task ShowNewLevel()
            {
                var newLevel = _levels[_number];
                _selector.ShowTo(newLevel.transform, "A new simulator is <color=#2DFF00>open</color>");
                newLevel.Open();
                await Task.Delay(TimeSpan.FromSeconds(3));
                _selector.ShowBack();
            }
            void Spawn()
            {
                _zoneEnemy.SpawnMax(_number);
                SpawnBoss();
            }
        }
        private void SpawnBoss()
        {
            var currentLevel = _bossLevels[_number];
            _zoneBoss.Spawn(currentLevel,_selector);
        }

        public void AllOpen()
        {
            _levels.ForEach(level => level.Open());
        }
    }
}
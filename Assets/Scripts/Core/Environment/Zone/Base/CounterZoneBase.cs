using System;
using System.Collections.Generic;
using Core.Characters.Fighter;
using Core.Components.Base;
using Core.Components.Detachment;
using Core.Components.Detachment.Formation;
using NaughtyAttributes;
using NTC.Global.Pool;
using UnityEngine;

namespace Core.Environment.Zone.Base
{
    public class CounterZoneBase : SaveLoadComponent
    {
        [SerializeField] private protected bool _isSaveSpawn = true;
        [Space][SerializeField] private LevelZone _levelZone;
        [SerializeField] private DetectorDetachment _detector;
        [SerializeField] private Fighter _prefab;
        [SerializeField] private Transform _pool;
        [SerializeField] private protected List<Fighter> _fighters = new();
        private float _spacing = 1;
        private int _level;
        public event Action<int, int> OnUpdateCount;
        protected int MaxCount => _levelZone.CurrentTemplate.MaxCount;
        protected virtual int LevelFighter => Level;
        public bool IsHave => _fighters.Count > 0;
        public bool IsEnter => _detector.IsEnter;

        #region Enable / Disable
        private void OnEnable()
        {
            _detector.OnEnterDetachment += DetachmentMethood;
            _levelZone.OnUpdate += UpdateCount;
            if (_isSaveSpawn)
            {
                Spawn(LevelFighter);
            }
        }
        private void OnDisable()
        {
            _detector.OnEnterDetachment -= DetachmentMethood;
            _levelZone.OnUpdate -= UpdateCount;
        }
        #endregion

        private void Start()
        {
            UpdateCount();
        }

        protected virtual void DetachmentMethood(Detachment detachment) { }
        
        protected void Spawn(int level,bool maxSpawn = false,int addCount = 0)
        {
            _level = level;
            if (_level < 0) return;
            var loadCount = Load() + addCount > MaxCount ? Load() : Load() + addCount;
            var count = maxSpawn ? MaxCount : loadCount;
            
            for (var i = 0; i < count; i++)
            {
                Add(false);
            }
            Formation();
        }

        [Button]
        private void Add(bool isFormation = true)
        {
            if (_level < 0) return;

            var fighter = NightPool.Spawn(_prefab,_pool);
            fighter.Level.Load(_level);
            fighter.Movement.SetSpawn(transform.position);
            _fighters.Add(fighter);
            if(isFormation) Formation();

        }
        [Button]
        private void Remove()
        {
            var lastFighter = _fighters[^1];
            _fighters.Remove(lastFighter);
            NightPool.Despawn(lastFighter);
            Formation();
        }
        [Button]
        protected void Clear()
        {
            if (_fighters.Count <= 0) return;
            
            _fighters.ForEach(fighter => NightPool.Despawn(fighter));
            _fighters = new List<Fighter>();
        }
        [Button]
        protected void Formation()
        {
            UpdateCount();
            if(IsHave == false) return;
            
            var columnCount = _levelZone.CurrentTemplate.ColumnCount;
            var formation = new RectangleFormation(columnCount, _spacing);
            var result = formation.GetPositions(_fighters.Count);

            for (var i = 0; i < _fighters.Count; i++)
            {
                _fighters[i].transform.parent = _pool;
                _fighters[i].Formation(_pool.position + result[i]);
            }
        }

        private void UpdateCount()
        {
            OnUpdateCount?.Invoke(_fighters.Count,MaxCount);
            Save(_fighters.Count);
        }
    }
}
using System;
using System.Collections.Generic;
using Core.Characters._Base;
using Core.Characters.Fighter;
using Core.Components.Detachment.Formation;
using NaughtyAttributes;
using NTC.Global.Pool;
using UnityEngine;

namespace Core.Components.Detachment
{
    public class Detachment : MonoBehaviour
    {
        [Header("Setting")]
        [SerializeField] private protected int _maxCount = 10;
        [SerializeField] private int _columnCount = 4;
        [SerializeField] private float _spacing = 1;
        
        [Space][SerializeField] private UpdaterPosition _updaterPosition;
        [SerializeField] private Fighter _prefab;
        [SerializeField] private List<Fighter> _fighters = new();
        public event Action<int,int> OnUpdateCount;
        public IEnumerable<Fighter> Fighters => _fighters;
        public bool HasCanAdd => _fighters.Count + 1 <= _maxCount;
        public bool IsHave => _fighters.Count > 0;
        public int Count => _fighters.Count;

        #region Enable/Disable
        private void OnEnable()
        {
            _updaterPosition.OnChangePosition += GroupMovement;
        }
        private void OnDisable()
        {
            _updaterPosition.OnChangePosition -= GroupMovement;
        }
        #endregion
        

        [Button]
        public void Spawn(int level = 0)
        {
            var fighter = NightPool.Spawn(_prefab);
            fighter.Deformation();
            fighter.Level.Load(level);
            fighter.Movement.SetSpawn(transform.position);
            Add(fighter);
        }
        public void Add(Fighter fighter)
        {
            _fighters.Add(fighter);
            UpdateCount();
        }
        public void Remove(List<Fighter> fighters)
        {
            fighters.ForEach(fighter => _fighters.Remove(fighter));
            UpdateCount();
        }
        private void GroupMovement(Vector3 center)
        {
            if (IsHave == false) return;

            var formation = new RectangleFormation(_columnCount, _spacing);
            var result = formation.GetPositions(_fighters.Count);
            
            for (var i = 0; i < _fighters.Count; i++)
            {
                var movement = _fighters[i].Movement;
                movement.SetToPlayer(center + result[i]);
            }
        }

        protected void UpdateCount()
        {
            OnUpdateCount?.Invoke(_fighters.Count,_maxCount);
        }
    }
}
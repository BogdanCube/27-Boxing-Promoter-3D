using System;
using System.Collections.Generic;
using Core.Characters.Fighter;
using Core.Components.Detachment;
using DG.Tweening;
using UnityEngine;

namespace Core.Environment.Zone.Base
{
    public class CounterZone : CounterZoneBase
    {
        private List<Fighter> _tempFighters = new();
        public bool IsMaxCount => Count + 1 > MaxCount;
        protected int Count => _fighters.Count + _tempFighters.Count;
        public int OpenCount => MaxCount - Count;
        public bool HasCanAdd(int count = 1) => Count + count <= MaxCount;

        protected void Push(Detachment detachment, int level)
        {
            var pushFighter = detachment.Fighters;
            var addedFighter = new List<Fighter>();
            foreach (var fighter in pushFighter)
            {
                if (_fighters.Count + 1 > MaxCount) break;
                
                if (fighter.Level.CurrentLevel == level || level < 0)
                {
                    _fighters.Add(fighter);
                    addedFighter.Add(fighter);
                }
            }
            detachment.Remove(addedFighter);
            Formation();
        }

        public void Add(Fighter fighter)
        {
            _tempFighters.Add(fighter);
        } 
        public void Push(Fighter fighter)
        {
            var sequence = DOTween.Sequence()
                .Append(fighter.Formation(transform.position))
                .OnComplete(() =>
                {
                    if (_tempFighters.Contains(fighter))
                    {
                        _tempFighters.Remove(fighter);
                    }
                    _fighters.Add(fighter);
                    Formation();
                });
        }
        protected List<Fighter> Pull(bool hasCanAdd)
        {
            var pullFighters = new List<Fighter>();
            for (int i = 0; i < _fighters.Count && hasCanAdd; i++)
            {
                var currentFighter = _fighters[i];

                currentFighter.Deformation();
                pullFighters.Add(currentFighter);
            }
            pullFighters.ForEach(fighter => _fighters.Remove(fighter));
            Formation();
            return pullFighters;
        }

        protected Fighter GetFighter()
        {
            var pullFighter = _fighters[0];
            _fighters.Remove(pullFighter);
            Formation();
            return pullFighter;
        }
    }
}
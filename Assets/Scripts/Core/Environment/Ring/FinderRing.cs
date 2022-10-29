using System;
using System.Collections.Generic;
using Core.Characters.Fighter;
using Core.Characters.Fighter.Fighting;
using Core.Environment.Zone;
using Core.Environment.Zone.PushZone;
using DG.Tweening;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Environment.Ring
{
    public class FinderRing : MonoBehaviour
    {
        [SerializeField] private PushZone _pushZone;
        private Transform _place;
        private Fighter _fighter;
        private int _countCheck;
        public event Action<FightingComponent> OnMoved;
        
        #region Enable / Disable
        private void OnEnable()
        {
            _pushZone.OnPush += CheckFighter;
            _pushZone.OnCheckHavePlace += CheckFighter;
        }
        private void OnDisable()
        {
            _pushZone.OnPush -= CheckFighter;
            _pushZone.OnCheckHavePlace -= CheckFighter;
            if (_fighter != null) _fighter.HealthComponent.OnDeath -= Push;
        }
        private bool CheckFighter(int count)
        {
            if (_countCheck > 0) return false;
            _countCheck++;
            return true;
        }

        #endregion

        private void Start()
        {
            if(_countCheck == 0)
                Push();
        }

        private void CheckFighter(List<Fighter> fighters)
        {
            if (fighters.Count <= 0 || _countCheck <= 0) return;
            MoveToRing(fighters[0]);

        }
        public void MoveToRing(Fighter fighter)
        {
            _fighter = fighter;
            _fighter.HealthComponent.OnDeath += Push;
            var sequence = DOTween.Sequence()
                .Append(_fighter.Formation(transform.position))
                .OnComplete(() =>
                {
                    OnMoved?.Invoke(_fighter.FightingComponent);
                });
        }
        private void Push()
        {
            _countCheck = 0;
            _pushZone.PushTo();
        }
    }
}
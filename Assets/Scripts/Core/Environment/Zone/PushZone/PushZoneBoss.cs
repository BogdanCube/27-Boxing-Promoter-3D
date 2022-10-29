using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Base.Level;
using Core.Characters.Fighter;
using Core.Environment.Ring;
using DG.Tweening;
using NTC.Global.Pool;
using NTC.Global.System;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Environment.Zone.PushZone
{
    public class PushZoneBoss : MonoBehaviour
    {
        [SerializeField] private PushZoneEnemy _pushZone;
        [SerializeField] private FinderRing _finder;
        [SerializeField] private Fighter _prefabBoss;
        [SerializeField] private Transform _pool;
        [SerializeField] private ButtonPushBoss _button;
        private SelectorCamera _selector;
        private Fighter _boss;
        public event Action OnBossDeath;
        private bool IsDeath => _boss && _boss.HealthComponent.IsDeath;
        #region Enable / Disable
        private void OnEnable()
        {
            _pushZone.OnEndFighters += EnableButton;
        }
        private void OnDisable()
        {
            _pushZone.OnEndFighters -= EnableButton;
            if (_boss != null) _boss.HealthComponent.OnDeath += Death;
        }
        
        private async void EnableButton()
        {
            if(IsDeath) return;
            
            _selector .ShowTo(_button.transform, "Press to fight a <color=#E0B62A>boss</color>");
            _button.Activate();
            await Task.Delay(TimeSpan.FromSeconds(5));
            _selector.ShowBack();
        }

        #endregion

        public void Spawn(int level, SelectorCamera selector)
        {
            _selector = selector;
            _button.Deactivate();
            
            _boss = NightPool.Spawn(_prefabBoss,_pool);
            _boss.Level.Load(level);
            _boss.Movement.SetSpawn(transform.position);
            _boss.HealthComponent.OnDeath += Death;
        }

        private void Death()
        {
            OnBossDeath?.Invoke();
        }

        public void Kill()
        {
            _boss.HealthComponent.Death();
        }
        public void Push()
        {
            _finder.MoveToRing(_boss);
            _button.Deactivate();
        }
    }
}
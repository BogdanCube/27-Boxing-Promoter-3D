using System;
using System.Threading.Tasks;
using DG.Tweening;
using NTC.Global.Pool;
using UnityEngine;

namespace Core.Characters.Fighter.Health
{
    public class DisplayDeath : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private Transform _fighter;

        #region Enable / Disable
        private void OnEnable()
        {
            _healthComponent.OnDeath += Death;
        }

        private void OnDisable()
        {
            _healthComponent.OnDeath -= Death;
        }
        #endregion
        
        private async void Death()
        {
            await Task.Delay(TimeSpan.FromSeconds(1.5f));
            _fighter.DOScale(Vector3.zero, 1).OnComplete(() =>
            {
                Destroy(_fighter.gameObject);
            });
        }
    }
}
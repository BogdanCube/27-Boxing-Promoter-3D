using System;
using System.Threading.Tasks;
using Core.Characters.Fighter;
using Core.Environment.Zone.Base;
using DG.Tweening;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Environment.TrainingZone.Simulator
{
    public class Simulator : MonoBehaviour
    {
        [SerializeField] private Transform _trainingPlace;
        [SerializeField] private Transform _inventory;
        private Fighter _currentFighter;
        public Action<Fighter> OnEndTraining;
        public bool IsBusy => _currentFighter != null;
        public void SetFighter(Fighter fighter, float duration)
        {
            _currentFighter = fighter;
            var sequence = DOTween.Sequence()
                .Append(fighter.Formation(_trainingPlace.position))
                .OnComplete(async () =>
                {
                    fighter.transform.DORotate(new Vector3(0, -90, 0), 0.2f);
                    await Task.Delay(TimeSpan.FromSeconds(0.2f));
                    if(_inventory) _inventory.Deactivate();
                    
                    fighter.Level.StartUpgrading(duration).OnComplete(async () =>
                    {
                        fighter.Level.LevelUp();
                        _currentFighter = null;
                        await Task.Delay(TimeSpan.FromSeconds(0.275f));
                        if(_inventory) _inventory.Activate();
                        OnEndTraining?.Invoke(fighter);
                    });
                });
        }
    }
}
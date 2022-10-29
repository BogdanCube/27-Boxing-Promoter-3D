using System;
using System.Collections.Generic;
using System.Linq;
using Core.Characters.Fighter;
using Core.Environment.Zone;
using Core.Environment.Zone.PushZone;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Environment.TrainingZone
{
    public class TrainingZone : MonoBehaviour
    {
        [SerializeField] private float _startedDuration;
        [SerializeField] private PushZone _pushZone;
        [SerializeField] private PullZone _pullZone;
        [SerializeField] private LevelTraining _levelTraining;
        [SerializeField] private List<Simulator.Simulator> _simulators = new();
        private int _countCheck;
        public float CurrentDuration => (float)Math.Round(_startedDuration - _startedDuration * (_levelTraining.Duration/100),2);
        #region Enable / Disable
        private void OnEnable()
        {
            _pushZone.OnCheckHavePlace += IsHavePlace;
            _pullZone.OnPull += Push;
            _pushZone.OnPush += Train;
            _simulators.ForEach(simulator => simulator.OnEndTraining += MoveToPull);
        }

        private bool IsHavePlace(int count)
        {
            return count < _pullZone.OpenCount;
        }
        public void AddSimulator(Simulator.Simulator simulator)
        {
            simulator.OnEndTraining += MoveToPull;
            _simulators.Add(simulator);
        }
        private void OnDisable()
        {
            _pushZone.OnCheckHavePlace -= IsHavePlace;
            _pullZone.OnPull -= Push;
            _pushZone.OnPush -= Train;
            _simulators.ForEach(simulator => simulator.OnEndTraining -= MoveToPull);
        }
        #endregion
        private void Train(List<Fighter> fighters)
        {
            foreach (var fighter in fighters)
            {
                foreach (var simulator in _simulators.Where(simulator => simulator.IsBusy == false))
                {
                    _pullZone.Add(fighter);
                    simulator.SetFighter(fighter, CurrentDuration);
                    break;
                }
            }
        }
        private void MoveToPull(Fighter fighter)
        {
            _pullZone.Push(fighter);
            Push();
        }

        private void Push()
        {
            _pushZone.PushTo();
        }
    }
}
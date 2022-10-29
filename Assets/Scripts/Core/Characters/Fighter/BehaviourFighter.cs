using Core.Characters._Base;
using Core.Characters.Fighter.Behaviour;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Characters.Fighter
{
    public class BehaviourFighter : BehaviourSystem
    {
        [SerializeField] private Fighter _fighter;
        private StateFighter _currentState;
        protected override IState CurrentState => _currentState;
        public Fighter Fighter => _fighter;
        public void SetState(StateFighter state)
        {
            if (_currentState != null) {
                _currentState.End();
            }
            _currentState = Instantiate(state);
            _currentState.BehaviourSystem = this;
            _currentState.Start();
        }

        protected override void SetIdleState()
        {
            SetState(ScriptableObject.CreateInstance<IdleStateFighter>());
        }

        [Button]
        public void SetTrainingState()
        {
            SetState(ScriptableObject.CreateInstance<TrainingStateFighter>());
        }
    }
}
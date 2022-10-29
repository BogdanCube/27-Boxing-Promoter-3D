using Core.Characters._Base;
using Core.Characters.Helper.Behaviour;
using UnityEngine;

namespace Core.Characters.Helper
{
    public class BehaviourHelper : BehaviourSystem
    {
        [SerializeField] private Helper _helper;
        private StateHelper _currentState;
        protected override IState CurrentState => _currentState;
        public Helper Helper => _helper;
        
        public void SetState(StateHelper state)
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
            SetState(ScriptableObject.CreateInstance<IdleStateHelper>());
        }
    }
}
using System;
using Core.Characters._Base;
using Core.Characters.Player.Behavior;
using NTC.Global.Cache;
using UnityEngine;

namespace Core.Characters.Player
{
    public class BehaviourPlayer : BehaviourSystem
    {
        [SerializeField] private Player _player;
        private StatePlayer _currentState;
        protected override IState CurrentState => _currentState;
        public Player Player => _player;
        public void SetState(StatePlayer state)
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
            SetState(ScriptableObject.CreateInstance<IdleState>());
        }
    }
}
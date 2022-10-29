using Core.Characters._Base;
using Core.Components;
using UnityEngine;

namespace Core.Characters.Player.Behavior
{
    public abstract class StatePlayer : ScriptableObject,IState
    {
        public BehaviourPlayer BehaviourSystem { get; set; }
        private Player Player => BehaviourSystem.Player;
        protected PlayerMovement Movement => Player.Movement;
        protected AnimationStateController Animation => Player.Animation;
        public virtual void Start() { } 
        public virtual void Update() { } 

        public virtual void End() { }
        
    }
}

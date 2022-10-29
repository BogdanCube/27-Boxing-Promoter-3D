using Core.Characters._Base;
using Core.Components.Detachment;
using Core.Environment.Zone;
using Core.Environment.Zone.PushZone;
using UnityEngine;

namespace Core.Characters.Helper.Behaviour
{
    public class StateHelper : ScriptableObject,IState 
    {
        public BehaviourHelper BehaviourSystem { get; set; }
        private Helper Helper => BehaviourSystem.Helper;
        protected PullZone PullZone => Helper.PullZone;
        protected PushZone PushZone => Helper.PushZone;
        protected HelperMovement Movement => Helper.Movement;
        protected AnimationHelper Animation => Helper.Animation;
        protected Detachment Detachment => Helper.Detachment;
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void End() { }
    }
}
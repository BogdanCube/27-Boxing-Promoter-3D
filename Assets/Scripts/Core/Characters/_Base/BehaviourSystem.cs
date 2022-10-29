using System;
using NaughtyAttributes;
using NTC.Global.Cache;
using UnityEngine;

namespace Core.Characters._Base
{
    public abstract class BehaviourSystem : NightCache,INightRun
    {
        public bool IsStop { private get; set; }
        [ShowNativeProperty] protected abstract IState CurrentState { get; }

        private void Awake()
        {
            SetIdleState();
        }
        public void Run()
        {
            if (IsStop == false)
            {
                CurrentState.Update();
            }
        }
        protected abstract void SetIdleState();
    }
}
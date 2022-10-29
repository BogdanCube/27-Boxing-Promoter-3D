using DG.Tweening;
using UnityEngine;

namespace Core.Characters.Helper.Behaviour
{
    public class WalkingPushStateHelper : StateHelper
    {
        public override void Start()
        {
            Animation.IsRunning = true;
            Movement.SetPosition(PushZone.transform);
        }

        public override void Update()
        {
            Movement.Move();
            
            if (Detachment.IsHave || PullZone.IsHave) return;
            BehaviourSystem.SetState(CreateInstance<WalkingStartStateHelper>());
        }
    }
}
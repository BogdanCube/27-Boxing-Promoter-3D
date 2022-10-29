using UnityEngine;

namespace Core.Characters.Helper.Behaviour
{
    public class IdleStateHelper : StateHelper
    {
        public override void Update()
        {
            if (Movement.IsPlaceStart)
            {
                Animation.IsRunning = false;
            }

            if (PushZone.IsMaxCount || PushZone.IsEnter) return;
            
            if(Detachment.IsHave && PushZone.HasCanAdd(Detachment.Count))
            {
                BehaviourSystem.SetState(CreateInstance<WalkingPushStateHelper>());
            }
            else if (PullZone.IsHave && PullZone.IsEnter == false)
            {
                BehaviourSystem.SetState(CreateInstance<WalkingPullStateHelper>());
            }
        }
    }
}
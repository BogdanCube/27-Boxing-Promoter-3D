using UnityEngine;

namespace Core.Characters.Helper.Behaviour
{
    public class WalkingPullStateHelper : StateHelper
    {
        public override void Start()
        {
            Animation.IsRunning = true;
            Movement.SetPosition(PullZone.transform);
        }

        public override void Update()
        {
            Movement.Move();
            if (Movement.IsMove == false)
            {
                BehaviourSystem.SetState(CreateInstance<IdleStateHelper>());
            }
        }
    }
}
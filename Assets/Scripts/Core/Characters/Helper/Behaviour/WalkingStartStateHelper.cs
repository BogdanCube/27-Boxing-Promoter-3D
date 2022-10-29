using UnityEngine;

namespace Core.Characters.Helper.Behaviour
{
    public class WalkingStartStateHelper : StateHelper
    {
        public override void Start()
        {
            Animation.IsRunning = true;
            Movement.SetStartPosition();
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
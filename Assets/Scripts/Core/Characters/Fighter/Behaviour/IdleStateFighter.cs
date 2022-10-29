namespace Core.Characters.Fighter.Behaviour
{
    public class IdleStateFighter : StateFighter
    {
        protected override void UpdateAction()
        {
            if (MovementController.IsMove)
            {
                BehaviourSystem.SetState(CreateInstance<RunningStateFighter>());
            }
        }
    }
}
namespace Core.Characters.Fighter.Behaviour
{
    public class DeathStateFighter : StateFighter
    {
        public override void Start()
        {
            Animation.SetDeath();
            BehaviourSystem.IsStop = true;
        }
    }
}
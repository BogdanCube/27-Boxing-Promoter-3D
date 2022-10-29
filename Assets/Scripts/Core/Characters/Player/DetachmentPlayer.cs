using Core.Components.Detachment;
using Core.Environment.UpgraderPlayer;

namespace Core.Characters.Player
{
    public class DetachmentPlayer : Detachment, IUpgrader
    {
        public void SetUpgrades(int maxCount)
        {
            _maxCount = maxCount;
                UpdateCount();
        }
    }
}
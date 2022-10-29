using Core.Characters._Base;
using Core.Components.Detachment;
using Core.Environment.Zone;
using Core.Environment.Zone.PushZone;
using UnityEngine;

namespace Core.Characters.Helper
{
    public class Helper : MonoBehaviour
    {
        [SerializeField] private PullZone _pullZone;
        [SerializeField] private PushZone _pushZone;
        [SerializeField] private HelperMovement _movement;
        [SerializeField] private AnimationHelper _animation;
        [SerializeField] private Detachment _detachment;
        public PullZone PullZone => _pullZone;
        public PushZone PushZone => _pushZone;
        public AnimationHelper Animation => _animation;
        public HelperMovement Movement => _movement;
        public Detachment Detachment => _detachment;
    }
}
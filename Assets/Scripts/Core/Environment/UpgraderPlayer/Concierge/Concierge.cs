using Core.Environment.Zone;
using UnityEngine;

namespace Core.Environment.UpgraderPlayer.concierge
{
    public class Concierge : MonoBehaviour
    {
        [SerializeField] private DetectorCharacter _detector;
        [SerializeField] private Animator _animator;
        [SerializeField] private Animator _helpAnimator;
        private readonly int _showNameId = Animator.StringToHash("Show");
        private readonly int _hideNameId = Animator.StringToHash("Hide");

        #region Enable / Disable
        private void OnEnable()
        {
            _detector.OnEnter += Show;
            _detector.OnExit += Hide;
        }
        private void OnDisable()
        {
            _detector.OnEnter -= Show;
            _detector.OnExit -= Hide;
        }
        #endregion
        private void Show()
        {
            _animator.SetTrigger(_showNameId);
            _helpAnimator.SetTrigger(_showNameId);
        }

        private void Hide()
        {
            _animator.SetTrigger(_hideNameId);
            _helpAnimator.SetTrigger(_hideNameId);
        }
    }
}
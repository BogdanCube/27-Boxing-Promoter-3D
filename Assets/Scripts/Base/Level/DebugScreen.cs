using TMPro;
using Toolkit.Extensions;
using UnityEngine;

namespace Base.Level
{
    public class DebugScreen : MonoBehaviour
    {
        [SerializeField] private Transform _gameScreen;
        [SerializeField] private Transform _adminScreen;
        [SerializeField] private Animator _animator;
        [SerializeField] private TextMeshProUGUI _text;
        private readonly int _showNameId = Animator.StringToHash("Show");
        private readonly int _hideNameId = Animator.StringToHash("Hide");
        private bool _isOpenAdmin;
        public void Show(string text)
        {
            _isOpenAdmin = _adminScreen.IsActive();
            _gameScreen.Deactivate();
            _adminScreen.Deactivate();
                
            transform.Activate();
            _animator.SetTrigger(_showNameId);
            _text.text = text;
        }
        public void Hide()
        {
            _animator.SetTrigger(_hideNameId);
            _gameScreen.Activate();
            if(_isOpenAdmin) _adminScreen.Activate();
            
            transform.Deactivate();
        }
    }
}
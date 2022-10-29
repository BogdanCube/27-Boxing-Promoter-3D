using Core.Characters.Fighter.Health;
using DG.Tweening;
using TMPro;
using UI.DisplayParameters.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.DisplayParameters
{
    public class DisplayHealth : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private Image _slider;
        [SerializeField] private Animator _animator;
        private bool _isUpdateCount;
        private readonly int _showNameId = Animator.StringToHash("Show");
        private readonly int _hideNameId = Animator.StringToHash("Hide");

        #region Enable / Disable
        private void OnEnable()
        {
            _healthComponent.OnUpdateCount += UpdateCount;
            _healthComponent.OnDeath += Hide;
        }
        private void OnDisable()
        { 
            _healthComponent.OnUpdateCount -= UpdateCount;
            _healthComponent.OnDeath += Hide;
        }
        #endregion
        private void Hide()
        {
            _animator.SetTrigger(_hideNameId);
        }

        private void Show()
        {
            _animator.SetTrigger(_showNameId);
        }
        
        private void UpdateCount(int currentCount,int maxCount)
        {
            if (_isUpdateCount == false)
            {
                Show();
            }
            _isUpdateCount = true;
            _slider.DOFillAmount((float) currentCount / maxCount, 0.3f);
        }
    }
}
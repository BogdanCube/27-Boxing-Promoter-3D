using System;
using System.Threading.Tasks;
using DG.Tweening;
using Toolkit.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Environment.Zone.PushZone
{
    public class ButtonPushBoss : MonoBehaviour
    {
        [SerializeField] private PushZoneBoss _zoneBoss;
        [SerializeField] private DetectorCharacter _detector;
        [SerializeField] private Image _button;
        [SerializeField] private Sprite _unPress;
        #region Enable / Disable
        private void OnEnable()
        {
            _detector.OnEnter += TurnOn;
        }
        private void OnDisable()
        {
            _detector.OnEnter -= TurnOn;
        }
        #endregion

        public void Activate()
        {
            transform.Activate();
            transform.DOScale(0, 0);
            transform.DOScale(1, 2);
        }
        private async void TurnOn()
        {
            _button.sprite = _unPress;
            await Task.Delay(TimeSpan.FromSeconds(1));
            _zoneBoss.Push();
        }
    }
}
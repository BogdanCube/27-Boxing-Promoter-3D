using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Environment.Zone.Model
{
    public class FillModelZone : MonoBehaviour
    {
        [SerializeField] private float _duration = 1.65f;
        [SerializeField] private float _durationExit = 0.75f;
        [SerializeField] private Image _outlineImage;
        private Tween _fillingTween;
        
        public void StartFill(Action callback)
        {
            _fillingTween = _outlineImage.DOFillAmount(1, _duration)
                .OnComplete(() =>
                {
                    callback?.Invoke();
                });
        }
        public void ExitFill(Action callback = null)
        {
            _fillingTween.Kill();
            _outlineImage.DOFillAmount(0, _durationExit)
                .OnComplete(() => callback?.Invoke());

        }
    }
}
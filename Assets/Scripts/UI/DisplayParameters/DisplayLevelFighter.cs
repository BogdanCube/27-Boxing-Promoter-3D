using Core.Characters.Fighter.Level;
using DG.Tweening;
using NTC.Global.Cache;
using TMPro;
using Toolkit.Extensions;
using UI.DisplayParameters.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.DisplayParameters
{
    public class DisplayLevelFighter : MonoBehaviour
    {
        [SerializeField] private LevelFighter _levelFighter;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _background;
        [SerializeField] private Image _inline;
        [SerializeField] private Image _outline;
        private void OnEnable()
        {
            _levelFighter.OnUpdateBar += UpdateBar;
            _levelFighter.OnStartUpgrading += StartUpgrading;
        }
        private void OnDisable()
        {
            _levelFighter.OnUpdateBar -= UpdateBar;
            _levelFighter.OnStartUpgrading -= StartUpgrading;
        }
        private void UpdateBar(int level, Color color)
        {
            if (_text != null) _text.text = level.ToString();
            _inline.fillAmount = 0;
            _outline.fillAmount = 0;
            
            _background.transform.DOShakeScale(0.5f, Vector3.one /2f);
            _background.DOColor(color, 0.3f);
            _inline.DOFillAmount(1, 0.5f);
            _inline.DOColor(color, 0.3f);
        }
        private Tween StartUpgrading(float duration)
        {
            _inline.fillAmount = 0;
            _outline.fillAmount = 0;
            return _outline.DOFillAmount(1, duration).SetEase(Ease.Linear);
        }
    }
}
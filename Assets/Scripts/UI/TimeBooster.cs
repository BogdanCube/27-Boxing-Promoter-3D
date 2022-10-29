using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TimeBooster : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _text;
        private void Start()
        {
            Time.timeScale = 1;
        }

        public void SetTime()
        {
            Time.timeScale = _slider.value;
            _text.text = $"TimeScale: {(int)Time.timeScale}";
        }
    }
}
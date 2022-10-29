using Core.Environment.Zone;
using Core.Environment.Zone.Base;
using TMPro;
using UnityEngine;

namespace UI.DisplayParameters
{
    public class DisplayCountZone : MonoBehaviour
    {
        [SerializeField] private CounterZone _counterZone;
        [SerializeField] private TextMeshProUGUI _text;
        private void OnEnable()
        {
            _counterZone.OnUpdateCount += UpdateCount;
        }
        private void OnDisable()
        {
            _counterZone.OnUpdateCount -= UpdateCount;

        }
        private void UpdateCount(int currentCount, int maxCount)
        {
            _text.text = $"{currentCount}/{maxCount}";
        }
    }
}
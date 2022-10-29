using Core.Components.Detachment;
using TMPro;
using UnityEngine;

namespace UI.DisplayParameters
{
    public class DisplayDetachment : MonoBehaviour
    {
        [SerializeField] private Detachment _detachment;
        [SerializeField] private TextMeshProUGUI _text;
        private void OnEnable()
        {
            _detachment.OnUpdateCount += UpdateCount;
        }
        private void OnDisable()
        {
            _detachment.OnUpdateCount -= UpdateCount;
        }
        private void UpdateCount(int currentCount, int maxCount)
        {
            _text.text = $"{currentCount}/{maxCount}";
        }
    }
}
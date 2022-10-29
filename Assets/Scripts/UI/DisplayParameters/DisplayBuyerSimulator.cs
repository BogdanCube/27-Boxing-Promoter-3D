using Core.Environment.TrainingZone.Simulator;
using TMPro;
using UnityEngine;

namespace UI.DisplayParameters
{
    public class DisplayBuyerSimulator : MonoBehaviour
    {
        [SerializeField] private PumperWallet _pumper;
        [SerializeField] private TextMeshProUGUI _text;
        private void OnEnable()
        {
            _pumper.OnUpdateCount += UpdateCount;
        }
        private void OnDisable()
        {
            _pumper.OnUpdateCount -= UpdateCount;
        }
        private void UpdateCount(int currentCount)
        {
            _text.text = $"{currentCount}";
        }
    }
}
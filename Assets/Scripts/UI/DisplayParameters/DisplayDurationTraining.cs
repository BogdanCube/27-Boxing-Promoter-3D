using Core.Environment.TrainingZone;
using TMPro;
using UnityEngine;

namespace UI.DisplayParameters
{
    public class DisplayDurationTraining : MonoBehaviour
    {
        [SerializeField] private TrainingZone _trainingZone;
        [SerializeField] private LevelTraining _levelTraining;
        [SerializeField] private TextMeshProUGUI _text;
        private void OnEnable()
        {
            _levelTraining.OnUpdate += UpdateCount;
        }
        private void OnDisable()
        {
            _levelTraining.OnUpdate -= UpdateCount;
        }
        private void UpdateCount()
        {
            _text.text = $"{_trainingZone.CurrentDuration}";
        }
    }
}
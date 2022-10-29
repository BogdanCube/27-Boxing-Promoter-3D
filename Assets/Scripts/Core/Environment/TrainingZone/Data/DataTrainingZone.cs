using System.Collections.Generic;
using UnityEngine;

namespace Core.Environment.TrainingZone.Data
{
    [CreateAssetMenu(menuName = "My Assets/DataTrainingZone")]

    public class DataTrainingZone : ScriptableObject
    {
        [SerializeField] private List<TemplateTrainingZone> _templates;
        public IReadOnlyList<TemplateTrainingZone> Templates => _templates;
    }
    [System.Serializable]
    public class TemplateTrainingZone
    {
        [SerializeField] private float _durationCoefficient;
        [SerializeField] private int _price;
        public float DurationCoefficient => _durationCoefficient;
        public int Price => _price;
    }
}
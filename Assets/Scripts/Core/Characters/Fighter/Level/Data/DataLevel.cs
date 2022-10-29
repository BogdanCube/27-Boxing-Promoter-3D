using System.Collections.Generic;
using UnityEngine;

namespace Core.Characters.Fighter.Level.Data
{
    [CreateAssetMenu(menuName = "My Assets/DataLevel")]
    public class DataLevel : ScriptableObject
    {
        [SerializeField] private List<TemplateLevel> _templates;
        public IReadOnlyList<TemplateLevel> Templates => _templates;
    }
    [System.Serializable]
    public class TemplateLevel 
    {
        [SerializeField] private Color _color;
        [SerializeField] private float _fatAmount;
        [SerializeField] private AnimationClip _trainingClip;
        [SerializeField] private int _health;
        [SerializeField] private int _damage;

        public Color Color => _color;
        public float FatAmount => _fatAmount;
        public AnimationClip TrainingClip => _trainingClip;
        public int Health => _health;
        public int Damage => _damage;

    }
}
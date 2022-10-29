using System.Collections.Generic;
using UnityEngine;

namespace Core.Characters.Fighter.Fighting.Data
{
    [CreateAssetMenu(menuName = "My Assets/FightingData")]
    public class FightingData : ScriptableObject
    {
        [SerializeField] private List<TemplateFighting> _templates;
        public List<TemplateFighting> Templates => _templates;
    }
    [System.Serializable]
    public class TemplateFighting
    { 
        [SerializeField] private AnimationClip _attackClip;
        [SerializeField] private float _hitDelay;
        [SerializeField] private AnimationClip _hitClip;
        [SerializeField] private float _attackDelay;

        public AnimationClip AttackClip => _attackClip;
        public float HitDelay => _hitDelay;
        public AnimationClip HitClip => _hitClip;
        public float AttackDelay => _attackDelay;
    }
}
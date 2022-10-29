using System.Collections.Generic;
using UnityEngine;

namespace Core.Environment.UpgraderPlayer.Data
{
    [CreateAssetMenu(menuName = "My Assets/DataUpgrader")]
    
    public class DataUpgrader : ScriptableObject
    {       
        [SerializeField] private List<TemplateUpgrader> _templates;
        public IReadOnlyList<TemplateUpgrader> Templates => _templates;
    }
    [System.Serializable]
    public class TemplateUpgrader
    {
        [SerializeField] private int _maxCount;
        [SerializeField] private int _price;
        
        public int MaxCount => _maxCount;
        public int Price => _price;
    }

}
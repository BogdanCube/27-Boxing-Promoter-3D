using System.Collections.Generic;
using UnityEngine;

namespace Core.Environment.Zone.Data
{
    [CreateAssetMenu(menuName = "My Assets/DataZone")]
    public class DataZone : ScriptableObject
    {
        [SerializeField] private List<TemplateZone> _templates;
        public IReadOnlyList<TemplateZone> Templates => _templates;
    }
    [System.Serializable]
    public class TemplateZone
    {
        [SerializeField] private Vector2 _size;
        [SerializeField] private int _columnCount;
        [SerializeField] private int _maxCount;
        [SerializeField] private int _price;
        [SerializeField] private Sprite _background;
        [SerializeField] private Sprite _outline;
        public Vector2 Size => _size;
        public int ColumnCount => _columnCount;
        public int MaxCount => _maxCount;
        public int Price => _price;
        public Sprite Background => _background;
        public Sprite Outline => _outline;
    }
}
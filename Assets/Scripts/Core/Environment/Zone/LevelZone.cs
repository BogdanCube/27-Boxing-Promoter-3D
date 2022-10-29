using Core.Components.Base;
using Core.Environment.Zone.Data;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Environment.Zone
{
    public class LevelZone : LevelBase
    {
        [SerializeField] [Expandable] private DataZone _dataZone;
        public TemplateZone CurrentTemplate => _dataZone.Templates[CurrentLevel];
        protected override int MaxLevel => _dataZone.Templates.Count;
        public override bool IsMaxLevel => CurrentLevel + 1 >= _dataZone.Templates.Count;
        public override int Price => CurrentTemplate.Price;
        public override string Description => ConvertUpgrade(CurrentTemplate.MaxCount, 
                    _dataZone.Templates[CurrentLevel + 1].MaxCount);

    }
}
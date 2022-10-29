using Core.Components.Base;
using Core.Environment.UpgraderPlayer.Data;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Environment.UpgraderPlayer
{
    public class LevelUpgraderPlayer : LevelBase
    {
        [SerializeField, InterfaceType(typeof(IUpgrader))] private Object _upgrader;
        [SerializeField] [Expandable] private DataUpgrader _data;
        private TemplateUpgrader CurrentTemplate => _data.Templates[CurrentLevel];
        protected override int MaxLevel => _data.Templates.Count;
        public override bool IsMaxLevel => CurrentLevel + 1 >= _data.Templates.Count;
        public override int Price => CurrentTemplate.Price;
        public override string Description => ConvertUpgrade(CurrentTemplate.MaxCount, 
            _data.Templates[CurrentLevel + 1].MaxCount);

        private IUpgrader Upgrader => (IUpgrader)_upgrader;
        
        protected override void LevelUpAction()
        {
            Upgrader.SetUpgrades(CurrentTemplate.MaxCount);
        }
    }
}
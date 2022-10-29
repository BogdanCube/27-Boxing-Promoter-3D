using System.Collections.Generic;
using Core.Components.Base;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Environment.TrainingZone.Upgrade
{
    public class UpgraderLevel : MonoBehaviour
    {
        [SerializeField] private string _title;
        [SerializeField] private Sprite _icon;
        [SerializeField] private LevelBase _levelBase;
        public bool IsMaxLevel => _levelBase.IsMaxLevel;
        public int Price => _levelBase.Price;
        public string Description => _levelBase.Description;
        public string Title => _title;
        public Sprite Icon => _icon;

        [Button]
        public void LevelUps()
        {
            _levelBase.LevelUp();
        }
    }
}
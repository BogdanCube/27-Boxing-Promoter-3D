using System;
using System.Globalization;
using Core.Components.Base;
using Core.Environment.TrainingZone.Data;
using Core.Environment.Zone.Data;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Environment.TrainingZone
{
    public class LevelTraining : LevelBase
    {
        [SerializeField] [Expandable] private DataTrainingZone _dataZone;
        private TemplateTrainingZone CurrentTemplate => _dataZone.Templates[CurrentLevel];
        protected override int MaxLevel => _dataZone.Templates.Count;
        public override bool IsMaxLevel => CurrentLevel + 1 >= MaxLevel;
        public override int Price => _dataZone.Templates[CurrentLevel].Price;
        public override string Description => ConvertUpgrade(Duration, 
                         _dataZone.Templates[CurrentLevel + 1].DurationCoefficient);
        public float Duration => CurrentTemplate.DurationCoefficient;

    }
}
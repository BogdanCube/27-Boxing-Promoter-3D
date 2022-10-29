using System;
using System.Collections.Generic;
using Base.Level;
using Core.Components.Base;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Environment.Ring
{
    public class ObserverPrize : SaveLoadComponent
    {
        [SerializeField] private LoaderLevel _loader;
        [SerializeField] private Transform _parentPrize;
        private List<Transform> _prizes =  new();
        private int _count;
        #region Enable/Disable
        private void OnEnable()
        {
            _loader.OnLevelUp += AddPrize;
        }
        private void OnDisable()
        {
            _loader.OnLevelUp -= AddPrize;
        }
        #endregion

        private void Start()
        {
            _count = Load();
            _prizes.AddRange(_parentPrize.GetComponentsInChildren<Transform>());
            _prizes.ForEach(prize => prize.Deactivate());
            for (var i = 0; i < _count; i++)
            {
                _prizes[i].Activate();
            }
        }

        private void AddPrize()
        {
            _count++;
            if (_count >= _prizes.Count) return;
            _parentPrize.Activate();
            _prizes[_count].Activate();
            Save(_count);
        }
    }
}
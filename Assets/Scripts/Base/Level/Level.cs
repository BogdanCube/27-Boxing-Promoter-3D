using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NaughtyAttributes;
using Toolkit.Extensions;
using UnityEngine;

namespace Base.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private List<Transform> _openObjects;
        [SerializeField] private bool _isDelay = true;
        [SerializeField] private Transform _lock;
        [Button]
        public async void Open()
        {
            if (_lock != null) _lock.Deactivate();
            foreach (var openObject in _openObjects)
            {
                openObject.Activate();
                if(_isDelay) await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
        [Button]
        public void Close()
        {
            if (_lock != null) _lock.Activate();
            _openObjects.ForEach(openObject => openObject.Deactivate());
        }
    }
}
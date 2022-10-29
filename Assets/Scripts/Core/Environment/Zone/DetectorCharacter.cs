using System;
using Core.Characters._Base;
using Core.Characters.Player;
using Core.Components;
using Core.Components.Detachment;
using Core.Environment.Zone.Data;
using Core.Environment.Zone.Model;
using UnityEngine;

namespace Core.Environment.Zone
{
    public class DetectorCharacter : MonoBehaviour
    {
        [SerializeField] private FillModelZone _fillModel;
        public event Action OnEnter;
        public event Action OnExit;
        private bool _isEnter;
        public bool IsEnter => _isEnter;
        private void OnTriggerStay(Collider other)
        {
            if (_isEnter) return;

            if (other.TryGetComponent(out UpdaterPosition movement) && movement.IsMove == false)
            {
                _isEnter = true;
                OnEnter?.Invoke();
                if (_fillModel)
                {
                    _fillModel.StartFill(() => EnterAction(other));
                }
                else
                {
                    EnterAction(other);
                }
            }
        }
        
        protected virtual void EnterAction(Collider other) { }
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out UpdaterPosition movement))
            {
                _isEnter = false;
                OnExit?.Invoke();
                if (_fillModel)
                {
                    _fillModel.ExitFill(() => ExitAction(other));
                }
                else
                {
                    ExitAction(other);
                }
            }
        }
        protected virtual void ExitAction(Collider other) { }

    }
}
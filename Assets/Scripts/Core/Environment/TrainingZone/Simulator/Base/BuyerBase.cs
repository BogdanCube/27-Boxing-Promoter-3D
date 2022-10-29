using Core.Environment.Zone.Base;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Environment.TrainingZone.Simulator.Base
{
    public abstract class BuyerBase : MonoBehaviour
    {
        [SerializeField, Header("Test")] private bool _isBuy;
        [SerializeField] private PumperWallet _pumper;
        #region Enable / Disable
        private void OnEnable()
        {
            _pumper.OnBuy += Set;
        }
        
        private void OnDisable()
        {
            _pumper.OnBuy -= Set;
        }
        #endregion

        private void Start()
        {
            if (_pumper.IsBuy || _isBuy)
            {
                Set();
            }
            else
            {
                _pumper.Activate();
                UnSetAction();
            }
        }
        
        private void Set()
        {
            SetAction();
            _pumper.Deactivate();
        }

        protected abstract void SetAction();
        protected abstract void UnSetAction();
    }
}
using Core.Characters.Helper;
using Core.Environment.TrainingZone.Simulator.Base;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Environment.Zone
{
    public class BuyerHelper : BuyerBase
    {
        [SerializeField] private Helper _helper;
        protected override void SetAction()
        {
            _helper.Activate();
        }

        protected override void UnSetAction()
        {
            _helper.Deactivate();
        }
    }
}
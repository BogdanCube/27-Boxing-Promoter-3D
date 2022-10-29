using Base.Level;
using Core.Environment.TrainingZone.Simulator.Base;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Environment.Ring.CollectorMoney.Arena
{
    public class BuyerArena : BuyerBase
    {
        [SerializeField] private Arena _arena;
        [SerializeField] private NavMeshBaker _baker;
        protected override void SetAction()
        {
            _arena.Activate();
            _baker.UpdateBake();
        }

        protected override void UnSetAction()
        {
            _arena.Deactivate();
        }
    }
}
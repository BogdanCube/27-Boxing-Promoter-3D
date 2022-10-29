using System;
using Base.Level;
using Core.Environment.TrainingZone.Simulator.Base;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Environment.TrainingZone.Simulator
{
    public class BuyerSimulation : BuyerBase
    {
        [SerializeField] private NavMeshBaker _baker;
        [SerializeField] private Simulator _simulator;
        [SerializeField] private TrainingZone _trainingZone;
        
        protected override void SetAction()
        {
            _simulator.Activate();
            if (_baker) _baker.UpdateBake();
            _trainingZone.AddSimulator(_simulator);
        }

        protected override void UnSetAction()
        {
            _simulator.Deactivate();
        }
    }
}
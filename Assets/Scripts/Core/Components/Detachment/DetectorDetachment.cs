using System;
using Core.Environment.Zone;
using Core.Environment.Zone.Model;
using UnityEngine;

namespace Core.Components.Detachment
{
    public class DetectorDetachment : DetectorCharacter
    {
        public event Action<Detachment> OnEnterDetachment;

        protected override void EnterAction(Collider other)
        {
            if (other.TryGetComponent(out Detachment detachment))
            {
                OnEnterDetachment?.Invoke(detachment);
            }
        }

        protected override void ExitAction(Collider other)
        {
        }
    }
}
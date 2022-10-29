using System;
using Core.Characters.Fighter;
using Core.Components.Detachment;
using Core.Environment.Zone.Base;
using UnityEngine;

namespace Core.Environment.Zone
{
    public class PullZone : CounterZone
    {
        public event Action OnPull;
        protected override void DetachmentMethood(Detachment detachment)
        {
            var pullFighters = Pull(detachment.HasCanAdd);
            
            if (pullFighters.Count <= 0) return;
            pullFighters.ForEach(detachment.Add);
            OnPull?.Invoke();
        }
    }
}
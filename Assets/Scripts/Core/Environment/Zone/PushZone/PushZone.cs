using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Characters.Fighter;
using Core.Components.Detachment;
using Core.Environment.Zone.Base;
using UnityEngine;

namespace Core.Environment.Zone.PushZone
{
    public class PushZone : CounterZone
    {
        public event Func<int,bool> OnCheckHavePlace;
        public event Action<List<Fighter>> OnPush;
        public event Action OnEndFighters;
        protected override int LevelFighter => Level - 1;

        protected override void DetachmentMethood(Detachment detachment)
        {
            if (detachment.IsHave)
            {
                Push(detachment,LevelFighter);
                Invoke(nameof(PushTo),1);
            }
        }
        public void PushTo()
        {
            if (IsHave)
            {
                OnPush?.Invoke(FindFighters());
            }
            else
            {
                OnEndFighters?.Invoke();
            }
        }
        private List<Fighter> FindFighters()
        {
            var fighters = new List<Fighter>();
            var count = Count;
            for (var i = 0; i < count; i++)
            {
                var isNotBusy = OnCheckHavePlace?.Invoke(fighters.Count);
                if (isNotBusy == true && IsHave)
                {
                    fighters.Add(GetFighter());
                }
                else
                {
                    break;
                }
            }
            return fighters;
        }

    }
}
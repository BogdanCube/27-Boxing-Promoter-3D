using Core.Characters.Fighter.Fighting;
using UnityEngine;

namespace Core.Environment.Ring
{
    public class RingZone : MonoBehaviour
    {
        [SerializeField] private RingFighting _ring;
        [SerializeField] private FinderRing _firstFinder;
        [SerializeField] private FinderRing _secondFinder;
        private FightingComponent _firstFighter;
        private FightingComponent _secondFighter;
        
        #region Enable / Disable
        private void OnEnable()
        {
            _firstFinder.OnMoved += AddFirstFighter;
            _secondFinder.OnMoved += AddSecondFighter;
        }
        private void OnDisable()
        {
            _firstFinder.OnMoved -= AddFirstFighter;
            _secondFinder.OnMoved -= AddSecondFighter;
        }
        #endregion
        private void AddFirstFighter(FightingComponent fighter)
        {
            fighter.transform.localRotation = Quaternion.Euler(0,90,0);
            _firstFighter = fighter;
            StartFighting();
        }
        private void AddSecondFighter(FightingComponent fighter)
        {
            fighter.transform.localRotation = Quaternion.Euler(0,-90,0);
            _secondFighter = fighter;
            StartFighting();
        }
        private async void StartFighting()
        {
            if (_firstFighter && _secondFighter)
            {
                await _ring.StartCycle(_firstFighter, _secondFighter);
            }
        }
    }
}
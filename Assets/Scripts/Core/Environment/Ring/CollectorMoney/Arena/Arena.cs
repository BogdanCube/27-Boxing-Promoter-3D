using Core.Environment.Zone.Base;
using UnityEngine;

namespace Core.Environment.Ring.CollectorMoney.Arena
{
    public class Arena : MonoBehaviour
    {
        [SerializeField] private RingFighting _ring;
        [SerializeField] private CollectorMoney _collector;
        public RingFighting Ring => _ring;
        public CollectorMoney Collector => _collector;
    }
}
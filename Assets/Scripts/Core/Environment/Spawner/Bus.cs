using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Core.Environment.Spawner
{
    public class Bus : MonoBehaviour
    {
        [SerializeField] private float _startX;
        [SerializeField] private float _endX;
        [SerializeField] private float _speed = 5;
        [SerializeField] private Transform _model;
        public event Action OnArrived;
        private void Start()
        {
            StartMove();
        }

        public void StartMove()
        {
            _model.rotation = Quaternion.Euler(new Vector3(0,90,0));
            transform.DOMoveX(_startX, _speed).SetSpeedBased().SetEase(Ease.Linear).OnComplete(() =>
            {
                OnArrived?.Invoke();       
            });
        }
        public async void EndMove()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            _model.rotation = Quaternion.Euler(new Vector3(0,-90,0));
            transform.DOMoveX(_endX, _speed).SetSpeedBased().SetEase(Ease.Linear);
        }

    }
}
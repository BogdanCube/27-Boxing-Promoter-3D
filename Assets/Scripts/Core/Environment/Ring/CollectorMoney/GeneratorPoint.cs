using System;
using UnityEngine;

namespace Core.Environment.Ring.CollectorMoney
{
    public class GeneratorPoint : MonoBehaviour
    {
        [SerializeField] private int _limitMoney = 125;
        [SerializeField] private int _countInRow = 15;
        [SerializeField] private Transform[] _points;
        private Vector3[] _positionPoints;
        public int LimitMoney => _limitMoney;
        private void Awake()
        {
            GenerationPoint();
        }
        private void GenerationPoint()
        {
            float y = 0;
            _positionPoints = new Vector3[_limitMoney];
            for (int i = 0, j = 0, z = 0; j < _limitMoney; i++, j++, z++)
            {
                if (z > _countInRow)
                {
                    y += 0.25f;
                    z = 0;
                }

                if (i > _points.Length - 1)
                {
                    i = 0;
                }

                var position = new Vector3(_points[i].localPosition.x, y, _points[i].localPosition.z);
                _positionPoints[j] = position;
            }
        }
        public Vector3 GetPosition(int count)
        {
            return _positionPoints[count];
        }
    }
}
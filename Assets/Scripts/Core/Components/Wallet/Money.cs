using System;
using DG.Tweening;
using NTC.Global.Pool;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Components.Wallet
{
    public class Money : MonoBehaviour
    {
        private float _timeUp;
        private float _timeDown;

        public void Init(float timeUp,float timeDown)
        {
            _timeUp = timeUp;
            _timeDown = timeDown;
        }
        public void MoveTo(Transform parent, Vector3 position)
        {
            transform.parent = parent;
            transform.DOLocalMoveArc(position, _timeUp, _timeDown);
        }
        public void SetPosition(Vector3 position)
        {
            transform.localPosition = position;
        }

    }
}
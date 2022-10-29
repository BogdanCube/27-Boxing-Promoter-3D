using System;
using Cinemachine;
using Core.Characters.Player;
using Toolkit.Extensions;
using UnityEngine;

namespace Base.Level
{
    public class SelectorCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private DebugScreen _debugScreen;
        private Transform _player;

        private void Start()
        {
            _player = _camera.Follow;
        }

        public void ShowTo(Transform target,string text)
        {
            _debugScreen.Show(text);
            _camera.Follow = target;
        }

        public void ShowBack()
        {
            _debugScreen.Hide();
            _camera.Follow = _player;
        }
    }
}
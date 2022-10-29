using NTC.Global.Cache;
using UnityEngine;

namespace UI.DisplayParameters.Base
{
    public class DisplayToCamera : NightCache,INightRun
    {
        [SerializeField] private Camera _camera;

        private void Start()
        {
            if (_camera == false)
            {
                _camera = Camera.main;
            }
        }
        public void Run()
        {
            if (_camera)
            {
                transform.LookAt(_camera.transform);
            }
        }
    }
}
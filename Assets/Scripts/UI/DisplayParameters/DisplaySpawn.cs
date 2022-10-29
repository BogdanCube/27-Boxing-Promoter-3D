using System;
using Core.Environment.Spawner;
using DG.Tweening;
using UI.DisplayParameters.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.DisplayParameters
{
    public class DisplaySpawn : DisplayToCamera
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Image _image;
        private void OnEnable()
        {
            _spawner.OnSpawn += UpdateImage;
        }

        private void OnDisable()
        {
            _spawner.OnSpawn -= UpdateImage;
        }

        private Tween UpdateImage(float time)
        {
            _image.fillAmount = 0;
            return _image.DOFillAmount(1, time);
        }
    }
}
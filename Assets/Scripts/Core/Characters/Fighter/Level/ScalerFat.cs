using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Characters.Fighter.Level
{
    public class ScalerFat : MonoBehaviour
    {
        [SerializeField] private bool _isDebug;
        [SerializeField] private float _amount;
        [SerializeField] private float _coefficient = 2000;
        [SerializeField] private List<Renderer> _renderers;
        private const string NameID = "_deformation_strength";

        private void OnValidate()
        {
            if (_isDebug)
            {
                SetFat(_amount);
            }
        }

        public void SetFat(float amount)
        {
            foreach (var material in _renderers.SelectMany(renderer => renderer.materials))
            { 
                material.SetFloat(NameID, amount/_coefficient);
            }
        }
    }
}
using System;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Characters.Boss
{
    public class SelectorRandomBody : MonoBehaviour
    {
        [SerializeField] private Mesh[] _models;
        [SerializeField] private SkinnedMeshRenderer _renderer;

        private void Start()
        {
            _renderer.sharedMesh = _models.RandomItem();
        }
    }
}
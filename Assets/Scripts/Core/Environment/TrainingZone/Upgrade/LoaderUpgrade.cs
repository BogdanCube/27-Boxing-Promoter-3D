using System;
using System.Collections.Generic;
using Core.Characters.Player.Wallet;
using Core.Components.Wallet;
using NTC.Global.Pool;
using Toolkit.Extensions;
using UI.Upgrade;
using UnityEngine;

namespace Core.Environment.TrainingZone.Upgrade
{
    public class LoaderUpgrade : MonoBehaviour
    {
        [SerializeField] private UpgradeTemplate _prefab;
        [SerializeField] private Animator _animator;
        private readonly int _showNameId = Animator.StringToHash("Show");
        private readonly int _hideNameId = Animator.StringToHash("Hide");
        private List<UpgradeTemplate> _templates = new();
        public void Load(List<UpgraderLevel> upgraders, WalletPlayer wallet)
        {
            _animator.SetTrigger(_showNameId);

            for (var i = 0; i < upgraders.Count; i++)
            {
                var template = _templates.Count < upgraders.Count ? NightPool.Spawn(_prefab, transform) 
                    : transform.GetChild(i).GetComponent<UpgradeTemplate>();

                template.Activate();
                template.Load(upgraders[i],wallet,Reload);
                _templates.Add(template);
            }

            void Reload()
            {
                Load(upgraders,wallet);
            }
        }
        public void Deload()
        {
            _animator.SetTrigger(_hideNameId);
            var count = transform.childCount;
            for (var i = 0; i < count; i++)
            {
                transform.GetChild(i).Deactivate();
            }
        }
    }
}
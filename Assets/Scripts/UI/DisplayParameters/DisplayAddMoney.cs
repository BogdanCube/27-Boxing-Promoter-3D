using System;
using System.Threading.Tasks;
using Core.Characters.Player.Wallet;
using Core.Components.Wallet;
using DG.Tweening;
using NaughtyAttributes;
using NTC.Global.Pool;
using UnityEngine;

namespace UI.DisplayParameters
{
    public class DisplayAddMoney : MonoBehaviour
    {
        [SerializeField] private RectTransform _prefab;
        [SerializeField] private RectTransform _pool;
        [SerializeField] private float _duration = 1;
        [SerializeField] private WalletPlayer _wallet;

        #region Enable/Disable
        private void OnEnable()
        {
            _wallet.OnAdd += Add;
        }
        private void OnDisable()
        {
            _wallet.OnAdd -= Add;
        }
        #endregion

        [Button]
        private async void Add()
        {
            var icon = NightPool.Spawn(_prefab, _pool);
            await Task.Delay(TimeSpan.FromSeconds(0.5f));
            NightPool.Despawn(icon);
        }
    }
}
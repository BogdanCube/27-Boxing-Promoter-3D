using Core.Characters._Base;
using Core.Characters.Player.Wallet;
using Core.Components;
using Core.Components.Detachment;
using Core.Components.Wallet;
using UnityEngine;

namespace Core.Characters.Player
{
    public class Player : Character
    {
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private WalletPlayer _wallet;
        [SerializeField] private Detachment _detachment;
        [SerializeField] private AnimationStateController _animation;
        public AnimationStateController Animation => _animation;
        public PlayerMovement Movement => _movement;
        public WalletPlayer Wallet => _wallet;
        public Detachment Detachment => _detachment;
    }
}
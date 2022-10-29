using System;
using Core.Characters.Player;
using Core.Characters.Player.Wallet;
using Core.Environment.TrainingZone.Simulator;
using Core.Environment.Zone;
using Core.Environment.Zone.Model;
using UnityEngine;

namespace Core.Components.Wallet
{
    public class DetectorWalletPlayer : DetectorCharacter
    {
        public event Action<WalletPlayer> OnEnterWallet;
        
        protected override void EnterAction(Collider other)
        {
            if (other.TryGetComponent(out WalletPlayer wallet))
            {
                OnEnterWallet?.Invoke(wallet);
            }
        }
    }
}
using System;

namespace Core.Characters.Player.Wallet
{
    public interface IWallet
    {
        event Action<int> OnUpdateCount;
        void Spend(int count);
    }
}
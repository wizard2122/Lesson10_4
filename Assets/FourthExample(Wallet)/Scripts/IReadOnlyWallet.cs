using System;

public interface IReadOnlyWallet
{
    event Action<int> Changed;
    int Coins { get; }
    bool IsEnough(int coins);
}

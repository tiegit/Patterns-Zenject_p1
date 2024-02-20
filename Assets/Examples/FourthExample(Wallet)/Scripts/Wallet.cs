using System;

public class Wallet
{
    public event Action<int> CoinsChanged;

    public Wallet(int coins)
    {
        //Проверка на < 0

        Coins = coins;
    }

    public int Coins { get; private set; }

    public void AddCoins(int coins)
    {
        //Проверка на < 0

        Coins += coins;
        CoinsChanged?.Invoke(Coins);
    }

    public void Spend(int coins)
    {
        //Проверка на < 0

        Coins -= coins;
        CoinsChanged?.Invoke(Coins);
    }

    public bool IsEnough(int coins)
    {
        //Проверка на < 0

        return Coins >= coins;
    }
}

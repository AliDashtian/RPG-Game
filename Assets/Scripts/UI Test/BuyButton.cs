using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public FloatVariable Coin;

    public void Buy(int price)
    {
        if (Coin.Value >= price)
        {
            Coin.Value -= price;

            Coin.InvokeOnValueChanged();

            print(PlayerPrefs.GetFloat("Coin", 0));
        }
    }
}

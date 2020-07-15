using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public string itemName;
    public float itemCost;
    public string itemDesc;
    public float inStock;
    public float i = 0;

    public Text shopTxt;

    public CoinsScript coins; 

    public void Health()
    {
        itemName = "Life potion";
        itemCost = 5;
        inStock = 5;
        Buy();
    }

    public void Damage()
    {
        itemName = "Strength potion";
        itemCost = 5;
        inStock = 3;
        Buy();
    }

    public void Jump()
    {
        itemName = "Jump boots";
        itemCost = 20;
        inStock = 1;
        Buy();
    }

    public void Whip()
    {
        itemName = "Judas's Whip";
        itemCost = 10;
        inStock = 1;
        Buy();
    }

    public void Gun()
    {
        itemName = "M1911";
        itemCost = 10;
        inStock = 1;
        Buy();
    }

    public void Sword()
    {
        itemName = "Arthur's Sword";
        itemCost = 10;
        inStock = 1;
        Buy();
    }

    public void Buy()
    {
        if (i< inStock && coins.coinsAantal >= itemCost)
        {
            Debug.Log("Bedankt voor het kopen van " + itemName + ".");
            shopTxt.text = "Bedankt voor het kopen van " + itemName + ".";
            coins.coinsAantal -= itemCost;
            coins.coinTxt.text = coins.coinsAantal.ToString();
            i += 1;
        }
        else if (i < inStock && coins.coinsAantal < itemCost)
        {
            Debug.Log("Je hebt te weinig geld voor " + itemName + "!");
            shopTxt.text = "Je hebt te weinig geld voor " + itemName + "!";
        }
        else if (i >= inStock && coins.coinsAantal >= itemCost)
        {
            Debug.Log(itemName + " is uitverkocht.");
            shopTxt.text = itemName + " is uitverkocht.";
        }
        else if (i >= inStock && coins.coinsAantal < itemCost)
        {
            Debug.Log(itemName + " is uitverkocht.");
            shopTxt.text = itemName + " is uitverkocht.";
        }
    }
}

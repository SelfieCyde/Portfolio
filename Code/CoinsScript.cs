using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsScript : MonoBehaviour
{
    public Text coinTxt;
    public float coinsAantal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "coin")
        {
            SoundManagerScript.PlaySound("CoinPickup");
            coinsAantal += 1f;
            coinTxt.text = coinsAantal.ToString();
            Destroy(collision.gameObject);
        }
    }
    void Start()
    {
        coinTxt.text = coinsAantal.ToString();
    }

    void Update()
    {
        
    }
}

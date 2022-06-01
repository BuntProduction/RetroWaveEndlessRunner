using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPickUp : MonoBehaviour
{
    public int CoinsToAdd;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            CoinsManager.AddCoins(CoinsToAdd);
            Destroy(gameObject);
        }
    }
}

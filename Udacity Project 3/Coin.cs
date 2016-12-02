using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
	public GameObject coinPoof;
    //Create a reference to the CoinPoofPrefab

    public void OnCoinClicked() {
		Instantiate(coinPoof, transform.position, transform.rotation);
		Destroy(gameObject);
        // Make sure the poof animates vertically
        // Destroy this coin. Check the Unity documentation on how to use Destroy
    }

}

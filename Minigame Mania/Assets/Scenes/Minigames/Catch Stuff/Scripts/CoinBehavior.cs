using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Timer.gameEnd) Destroy(this.gameObject);
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        if (transform.position.y < -screenBounds.y) Destroy(this.gameObject);
    }
}

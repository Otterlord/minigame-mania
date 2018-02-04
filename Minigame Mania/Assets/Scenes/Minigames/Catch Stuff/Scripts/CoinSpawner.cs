using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {
    [SerializeField] private GameObject coin;
    public float waitTime = 3;
    private float timeLeft;
	
    void Start ()
    {
        timeLeft = waitTime;
    }

	// Update is called once per frame
	void Update () {
        if (Timer.gameEnd) Destroy(this.gameObject);
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = waitTime;
            GameObject thing = Instantiate(coin);
            Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            thing.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), 113.6f);
        }
	}
}

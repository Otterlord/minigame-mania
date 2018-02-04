using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
    public string name = "Kicky Boom";
    public KeyCode leftKey;
    public KeyCode rightKey;

    public GameObject scoreObject;
    public int score = 0;

    public float spd = 5;
    private AudioSource soundPlayer;

    void Start ()
    {
        soundPlayer = GetComponent<AudioSource>();
       
    }

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin") // if we collide with a coin, do stuff
        {
            score++;
            scoreObject.GetComponent<TextMeshProUGUI>().text = score.ToString();
            Destroy(other.gameObject);
            soundPlayer.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(leftKey)) transform.Translate(Vector2.left * spd * Time.deltaTime);
        else if (Input.GetKey(rightKey)) transform.Translate(Vector2.right * spd * Time.deltaTime);
        // Clamping
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x), transform.position.y);
    }
}

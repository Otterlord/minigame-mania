using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour {
    private TextMeshProUGUI timeText;
    public int time = 60;
    public static bool gameEnd = false;
    public GameObject end;

    // Audio
    public AudioClip one;
    public AudioClip two;
    public AudioClip three;
    public AudioClip four;
    public AudioClip five;
    public AudioClip six;
    public AudioClip seven;
    public AudioClip eight;
    public AudioClip nine;
    public AudioClip ten;
    public AudioClip beep;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        timeText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Thing());

    }

    IEnumerator Thing()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            timeText.text = time.ToString();
            if (time <= 10)
            {
                if (time == 10) source.clip = ten;
                if (time == 9) source.clip = nine;
                if (time == 8) source.clip = eight;
                if (time == 7) source.clip = seven;
                if (time == 6) source.clip = six;
                if (time == 5) source.clip = five;
                if (time == 4) source.clip = four;
                if (time == 3) source.clip = three;
                if (time == 2) source.clip = two;
                if (time == 1) source.clip = one;
                source.Play();
            }
        }
        gameEnd = true;
        source.clip = beep;
        source.Play();
        DetermineWinner();
    }
   

    void DetermineWinner()
    {
        string playerName = "error";
        int topScore = 0;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in players)
        {
            if (g.GetComponent<PlayerBehavior>().score > topScore)
            {
                topScore = g.GetComponent<PlayerBehavior>().score;
                playerName = g.GetComponent<PlayerBehavior>().name;
            }
        }
        print(playerName + " " + topScore);
        end.GetComponent<TextMeshProUGUI>().text = playerName + " has won.";
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
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
        bool tie = false;
        string playerName = "error";
        int topScore = 0;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players[0].GetComponent<PlayerBehavior>().score > players[1].GetComponent<PlayerBehavior>().score) playerName = players[0].GetComponent<PlayerBehavior>().name;
        else if (players[1].GetComponent<PlayerBehavior>().score > players[0].GetComponent<PlayerBehavior>().score) playerName = players[1].GetComponent<PlayerBehavior>().name;
        else
        {
            print("no winner");
            playerName = null;
        }

        if (playerName == null) timeText.text = "Tie!";
        else timeText.text = playerName + " is the winner!";
    }
}

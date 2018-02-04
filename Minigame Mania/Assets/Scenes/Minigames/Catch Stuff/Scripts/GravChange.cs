using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravChange : MonoBehaviour
{

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Use this for initialization
    void OnClick()
    {
        if (Physics2D.gravity == new Vector2(0, -9.8f)) Physics2D.gravity = new Vector2(-9.8f, 0);
        else Physics2D.gravity = new Vector2(0, -9.8f);
    }
}

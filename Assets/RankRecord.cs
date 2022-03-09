using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankRecord : MonoBehaviour
{
    public Text scorePlayer1;
    public Text scorePlayer2;
    private int p1;
    private int p2;

    // Start is called before the first frame update
    void Start()
    {
        p1 = PlayerPrefs.GetInt("scorePlayer1");
        p2 = PlayerPrefs.GetInt("scorePlayer2");

        scorePlayer1.text = p1.ToString();
        scorePlayer2.text = p2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

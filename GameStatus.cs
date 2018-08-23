using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

    [Range(0.1f, 10f)] [SerializeField] float speed;

    [SerializeField] int pointPerHit = 50;
    [SerializeField] Text text;
    [SerializeField] int currentScore;
    [SerializeField] bool isAutoPlayOn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = speed;
        text.text = "The Score is: " + currentScore.ToString();
		
	}
    
    public void addToScore()
    {
        currentScore += pointPerHit;
    }

    public bool IsAutoPlayOn()
    {
        return isAutoPlayOn;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeperScript : MonoBehaviour {

	public Text scoreTxt;
	private static int score;

	// Use this for initialization
	void Start () {
        scoreTxt.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Score(int points) {
        score += points;
        scoreTxt.text = score.ToString();
    }

    public void Reset()
    {
        score = 0;
    }
}

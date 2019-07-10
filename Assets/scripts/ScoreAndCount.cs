using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreAndCount : MonoBehaviour {

    public Text scoreText;
    public Text countText;
    int score;
    EnemyManager enemyManager;

	// Use this for initialization
	void Start () {
        score = 0;
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        scoreText.text = "Score: " + score;
        countText.text = "Count to fail:" + enemyManager.numberEnemy;
	}

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void DeleteScore() {
        score = 0;
        UpdateScore(score);
    }

    public void UpdateCount() {
        if(enemyManager.numberEnemy>=0)
            countText.text = "Count to fail:" + enemyManager.numberEnemy;
        else
            countText.text = "Count to fail: 0";
    }

}

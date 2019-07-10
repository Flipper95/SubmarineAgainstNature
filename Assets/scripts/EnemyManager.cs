using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

    public GameObject[] enemy;
    public int numberEnemy = 0;
    public float repeatTime = 2.5f;

    float speedMultiplier=1;
    float healthMultiplier = 1;
    float uWaterY = 0; //left upper wave Y coordinate for generate enemies under water
    float waterX = 0; //X coordinate for generate all enemies
    float fromWaterY = 0; //y interval from
    float toWaterY = 0; //y interval to
    GameObject dialog;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Generate", repeatTime, repeatTime);
        GameObject startWater = GameObject.Find("StartUpWave");
        uWaterY=startWater.transform.position.y * 1.16f;
        waterX = startWater.transform.position.x - 10;
        fromWaterY = startWater.transform.position.y * 0.398f;
        toWaterY = GameObject.Find("EndBottomWater").transform.position.y * 1.19f;
        if (numberEnemy == 0) numberEnemy = 10;
        dialog = GameObject.Find("DialogBox");
        ChangeDifficult(GameObject.Find("DifficultValue").GetComponent<Text>().text);
        dialog.GetComponent<DialogBox>().Deactivate();
	}
	
	// Update is called once per frame
	void Generate () {
        int index = Random.Range(0, enemy.Length);
        Vector3 position;
        if (enemy[index].name == "USA-Radar")
            position = new Vector3(waterX, uWaterY, 0);
        else position = new Vector3(waterX, Random.Range(fromWaterY, toWaterY), 0);
        GameObject Enemy = Instantiate(enemy[index], position, Quaternion.identity) as GameObject;
        Enemy.GetComponent<EnemyController>().speed *= speedMultiplier;
        Enemy.GetComponent<EnemyController>().health *= healthMultiplier;
	}

    public void UpdateCount() {
        numberEnemy--;
        FindObjectOfType<ScoreAndCount>().UpdateCount();
        if (numberEnemy == 0)
        {
            dialog.SetActive(true);
            FindObjectOfType<DialogBox>().OpenDialogBox();
        }
    }

    public void ChangeDifficult(string difficult) {
        switch (difficult) {
            case ("Easy"): {
                speedMultiplier = 1;
                healthMultiplier = 1;
                repeatTime = 2.5f;
                numberEnemy = 15;
                break;
            }
            case ("Medium"): {
                speedMultiplier = 1.5f;
                healthMultiplier = 1;
                repeatTime = 2.0f;
                numberEnemy = 10;
                break;
            }
            case ("Hard"): {
                speedMultiplier = 1.5f;
                healthMultiplier = 1.2f;
                repeatTime = 1.5f;
                numberEnemy = 10;
                break;
            }
            default: {
                speedMultiplier = 1f;
                healthMultiplier = 1;
                repeatTime = 2.5f;
                numberEnemy = 15;
                break;
            }
        }
    }
}

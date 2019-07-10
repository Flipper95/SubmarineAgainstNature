using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    GameObject difficultBox;
    Text difficultText;

	// Use this for initialization
	void Start () {
        difficultBox = GameObject.Find("DifficultBox");
        difficultBox.SetActive(false);
        DontDestroyOnLoad(GameObject.Find("DifficultValue"));
        difficultText = GameObject.Find("DifficultValue").GetComponent<Text>();
        difficultText.text = "Easy";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnExitPush()
    {
        Application.Quit();
    }

    public void OnDifficultPush() {
        difficultBox.SetActive(true);
    }

    public void OnNewGamePush() {
        SceneManager.LoadScene("Game");
    }

    public void OnDifficultSelectPush(GameObject callObject) {
        //var colors = callObject.GetComponent<Button>().colors;
        //colors.normalColor = Color.red;
        //callObject.GetComponent<Button>().colors = colors;
        //GameObject.Find("DifficultValue").GetComponent<Text>().text = difficultText.text;
        switch (callObject.name) {
            case ("Easy"): { SetColorDifficult(Color.green, Color.white, Color.white); break; }
            case ("Medium"): { SetColorDifficult(Color.white, Color.yellow, Color.white); break; }
            case ("Hard"): { SetColorDifficult(Color.white, Color.white, Color.red); break; }
        }
        difficultText.text = callObject.name;
        difficultBox.SetActive(false);
    }

    void SetColorDifficult(Color easy, Color medium, Color hard) {
        GameObject.Find("Easy").GetComponent<Image>().color = easy;
        GameObject.Find("Medium").GetComponent<Image>().color = medium;
        GameObject.Find("Hard").GetComponent<Image>().color = hard;
    }

}

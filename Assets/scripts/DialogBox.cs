using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogBox : MonoBehaviour {

    GameObject control;

	// Use this for initialization
	void Start () {
        Canvas canvas = gameObject.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
        CanvasScaler scaler = gameObject.GetComponent<CanvasScaler>();
        scaler.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.matchWidthOrHeight = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenDialogBox() {
        control.SetActive(false);
    }

    public void Deactivate(){
        control = GameObject.Find("Control");
        gameObject.SetActive(false);
    }

    public void OnRestartPush() {
        GameObject.FindObjectOfType<EnemyManager>().ChangeDifficult(GameObject.Find("DifficultValue").GetComponent<Text>().text);
        ScoreAndCount scoreAndCount = GameObject.FindObjectOfType<ScoreAndCount>();
        scoreAndCount.DeleteScore();
        scoreAndCount.UpdateCount();
        control.SetActive(true);
        Deactivate();
    }

    public void OnLoadMenuPush() {
        SceneManager.LoadScene("Menu");
    }

}

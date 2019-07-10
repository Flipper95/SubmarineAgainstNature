using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    Vector2 horizontalAxis;
    float startPos = 0;
    bool secondTouch;
    float speed = 30.0F; //Fourth method

    public PlayerController playerController;

    void Start() 
    {
        Input.simulateMouseWithTouches = true;
        secondTouch = false;
    }

	// Update is called once per frame
	void Update () {
        /*First method
        print("Touch count:" + Input.touchCount);
        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            switch (touch.phase)
            {
                case (TouchPhase.Began): { startPos = touch.position.x; break; }
                case (TouchPhase.Moved):
                    {
                        if (touch.position.x - startPos < 0)
                        {
                            playerController.SetDirectionVector(new Vector2(-1, 0));
                            print("Swipe left");
                        }
                        else
                            playerController.SetDirectionVector(new Vector2(1, 0));
                        break;
                    }
                case (TouchPhase.Ended): { playerController.SetDirectionVector(new Vector2(0, 0)); break; }
            }
        }*/
        //playerController.SetDirectionVector(new Vector2(Input.GetAxisRaw("Horizontal"), 0)); //second method
        
        //third method
        /*
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition.x;
            playerController.Fire();
            //print("startPos: " + startPos);
        }
        else if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x - startPos > 0) playerController.SetDirectionVector(new Vector2(1, 0));
            else if (Input.mousePosition.x - startPos < 0) playerController.SetDirectionVector(new Vector2(-1, 0));
            //else playerController.Fire();
            //print("startPos: " + startPos + "|endPos: " + Input.mousePosition.x + "|Diff:" + (Input.mousePosition.x - startPos));
        }
        if (Input.GetMouseButtonUp(0))
        {
            playerController.SetDirectionVector(new Vector2(0, 0));
            //if (secondTouch)
            //    playerController.Fire();
            //secondTouch = !secondTouch;
        }*/
        
        //fourth method
        
        Vector2 dir = new Vector3(Input.acceleration.x, 0);
        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        dir *= Time.deltaTime;
        //transform.Translate(dir * speed);
        playerController.SetDirectionVector(dir*speed);
        if (Input.GetMouseButtonDown(0))
        {
            playerController.Fire();
        }
        
    }
}

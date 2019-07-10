using UnityEngine;
using System.Collections;
//using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigidBody;
    Vector2 directionVector = Vector3.zero;
    float speed = 1;
    float speedMultiplier = 6;
    long numberTorped = 0;

    public GameObject torpedo;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (directionVector.x != 0)
        {
            speed = speedMultiplier * directionVector.x;
        }
        else {
            speed = 0;
        }
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
	}

    public void SetDirectionVector(Vector2 direction)
    {
        directionVector = direction;
    }

    public void Fire() {
            GameObject clonedTorpedo = Instantiate(torpedo, transform.position, Quaternion.identity) as GameObject;
            clonedTorpedo.name = "Torpedo" + numberTorped;
            numberTorped++;
            Transform transformed = clonedTorpedo.GetComponent<Transform>();
            Vector2 newPosition = new Vector2(transformed.position.x - 0.2f, transformed.position.y+1);
            transformed.position = newPosition;
    }

}

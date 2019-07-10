using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed;
    public int score;
    public float health;

    Vector2 directionVector = Vector2.zero;
    Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
            throw new System.ArgumentNullException("Script require component: Rigidbody");
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.x > GameObject.Find("EndBottomWater").transform.position.x){//20) {
            FindObjectOfType<EnemyManager>().UpdateCount();
            Destroy(gameObject);
        }
        rigidBody.velocity = new Vector2(directionVector.x + speed, (float)directionVector.y);
	}

    public void ReceiveDamage(int Damage) {
        health -= Damage;
        if (health <= 0) {
            FindObjectOfType<ScoreAndCount>().UpdateScore(score);
            Destroy(gameObject);
        }
    }
}

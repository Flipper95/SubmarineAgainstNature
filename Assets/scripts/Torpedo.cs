using UnityEngine;
using System.Collections;

public class Torpedo : MonoBehaviour {

    public int damage;
    public float speed=1;

    Vector2 directionVector = Vector2.zero;
    Rigidbody2D rigidBody;
    ParticleSystem particalFire;
    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        particalFire = GetComponent<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidBody.velocity = new Vector2(directionVector.x, directionVector.y+speed);
	}

    void OnCollisionEnter2D(Collision2D colInfo) {
        if (colInfo.gameObject.name != "redOctoberUp" && colInfo.gameObject.tag!="Torpedo") {
            GameObject enemy = colInfo.gameObject;
            if(enemy.GetComponent<EnemyController>()!=null)
                colInfo.gameObject.GetComponent<EnemyController>().ReceiveDamage(damage);
            particalFire.Emit(150);
            Destroy(spriteRenderer);
            Destroy(colInfo.contacts[0].otherCollider);
            Destroy(colInfo.contacts[0].otherCollider.gameObject, 0.5f);
            //Destroy(gameObject);
        }
    }
}

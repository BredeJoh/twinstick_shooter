using UnityEngine;
using System.Collections;

public class Enemymovement : MonoBehaviour {

    public Transform enemylazerprefab;
    private int teller = 0;
    Vector3 move;
    public float speed = 1.0f;
	// Use this for initialization
	void Start () {
        if (transform.position.y == -32)
        {
            speed = -1.0f;
        }
	}
	
	// Update is called once per frame
	void Update () {
        move = new Vector3(0f, -0.1f, 0f);
        transform.position += move * speed;
        teller++;
        if (teller == 120 && Health.playerHealth != 0)
        {
            Instantiate(enemylazerprefab, transform.position, transform.rotation);
            teller = 0;
        }
	}
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "lazer")
        {
            Destroy(gameObject);
        }
    }
}

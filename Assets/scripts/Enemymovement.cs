using UnityEngine;
using System.Collections;

public class Enemymovement : MonoBehaviour {
	public GameObject spiller;
    public Transform enemylazerprefab;
    private int teller = 0;
    public float fart = 5.0f;
	// Use this for initialization
	void Start () {
//        if (transform.position.y == -32)
//        {
//            speed = -1.0f;
//        }
	}
	void moveTowards()
	{
		gameObject.transform.position = Vector2.MoveTowards (gameObject.transform.position, spiller.transform.position , Time.deltaTime * fart);
	}
	
	// Update is called once per frame
	void Update () {
        teller++;
        if (teller == 120 && Health.playerHealth != 0)
        {
            Instantiate(enemylazerprefab, transform.position, transform.rotation);
            teller = 0;
        }
	}
	void FixedUpdate()
	{
		moveTowards();
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

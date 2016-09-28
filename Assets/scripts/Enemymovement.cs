using UnityEngine;
using System.Collections;

public class Enemymovement : MonoBehaviour {
	private GameObject spiller;
    public Transform enemylazerprefab;
    public float fart = 5.0f;
	public Vector3 dist;
	public float disty;
    public int health = 3;
	// Use this for initialization
	void Start () {
        //        if (transform.position.y == -32)
        //        {
        //            speed = -1.0f;
        //        }
        StartCoroutine(Shoot(2f));
        spiller = GameObject.FindGameObjectWithTag("Player"); 
	}
	void distfinder() //finner distanse mellom spiller og enemy
	{

			dist = spiller.transform.position - transform.position;
		print (dist.magnitude);
			//disty = spiller.transform.position.y - transform.position.y;
	}
	void moveTowards()
	{
		gameObject.transform.position = Vector2.MoveTowards (gameObject.transform.position, spiller.transform.position , Time.deltaTime * fart);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
	void FixedUpdate()
	{
		distfinder ();
		if (dist.magnitude >= 2)// && disty <= -5 || disty >= 5) //stopper å bevege seg mot spiller når den er innenfor en viss distanse
		{
			moveTowards();

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
            health--;

            if(health <= 0)
            {
                Points.score++;
                Destroy(gameObject);
            }
            
        }
    }
    IEnumerator Shoot(float WaitTime)
    {
        if (Health.playerHealth != 0)
            //Instantiate(enemylazerprefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(WaitTime);
        StartCoroutine(Shoot(2f));
        
    }
}

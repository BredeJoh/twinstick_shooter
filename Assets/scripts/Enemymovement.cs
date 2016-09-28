using UnityEngine;
using System.Collections;

public class Enemymovement : MonoBehaviour {
	private GameObject spiller;
	private GameObject fiende;
    public Transform enemylazerprefab;
	private float a;
	private float b;
	public float fart;
	public float amp;
	public Vector3 dist;
	public Vector3 Rad;
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
		fiende = GameObject.FindGameObjectWithTag("Player"); 
	}
	void distfinder() //finner distanse mellom spiller og enemy
	{

			dist = spiller.transform.position - transform.position;
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
		a = 5f;
		b = 1f;
		amp = a* Mathf.Log(b*(dist.magnitude + 1f));

		if (dist.magnitude >= 10.0f) {
			fart = 5.0f;
		}
		else 
		{
			fart = 0.1f + amp;
		}
		distfinder ();
		if (dist.magnitude >= 2) //stopper å bevege seg mot spiller når den er innenfor en viss distanse
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

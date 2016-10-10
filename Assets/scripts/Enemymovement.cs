using UnityEngine;
using System.Collections;

public class Enemymovement : MonoBehaviour {
	private GameObject spiller;
	private GameObject fiende;
	public Rigidbody rb;
	private SpriteRenderer sRendrer;
    public Transform enemylazerprefab;
	private float a;
	private float b;
	private float r;
	public float fart;
	public float amp;
	public Vector3 dist;
	public Vector3 edist;
	public Vector3 Rad;
	public float disty;
    public int health = 100;
    float randomrotation;
	// Use this for initialization
	void Start () {
        //        if (transform.position.y == -32)
        //        {
        //            speed = -1.0f;
        //        }

		sRendrer = GetComponent<SpriteRenderer> ();
		r = Random.Range(2.0f, 6f);
		r = Random.Range(3.0f, 7.0f);
        randomrotation = Random.Range(-10f, 10f);
        StartCoroutine(Shoot(r));
        spiller = GameObject.FindGameObjectWithTag("Player");
		fiende = GameObject.FindGameObjectWithTag("enemy");
	}
	IEnumerator flash(float time)
	{
		yield return new WaitForSeconds (time);
		sRendrer.color = Color.red;
	}
	void distfinder() //finner distanse mellom spiller og enemy
	{

			dist = spiller.transform.position - transform.position;
			edist = fiende.transform.position - transform.position;
	}
	void moveTowards()
	{
		gameObject.transform.position = Vector2.MoveTowards (gameObject.transform.position, spiller.transform.position , Time.deltaTime * fart);
	}
    void moveAway()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, spiller.transform.position, Time.deltaTime * -fart);
    }
//	void keepDistance()
//	{
//		gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, fiende.transform.position, Time.deltaTime * -200);
//	}
	void rotateAroundPlayer()
	{
		if (randomrotation > 0)
			transform.RotateAround(spiller.transform.position, Vector3.forward, 5 * r * Time.deltaTime);
		else
			transform.RotateAround(spiller.transform.position, Vector3.back, 5 * r * Time.deltaTime);
	}
	// Update is called once per frame
	void Update () {
        
	}
	void FixedUpdate()
	{
		rotateAroundPlayer ();
        a = 3f;
		b = 1f;
		amp = (a* Mathf.Log(b*(dist.magnitude + 1f)))/2;

		if (dist.magnitude >= 10.0f) {
			fart = 2.0f;
		}
		else 
		{
			fart = 0.1f + amp;
			fart = Mathf.Clamp (fart, 0.0f, 4f);
		}
		distfinder ();
		if (dist.magnitude >= r) { //stopper å bevege seg mot spiller når den er innenfor en viss distanse
			moveTowards ();

		} else if (dist.magnitude < (r - 1f)) {
			moveAway ();
} 
		//else if (edist.magnitude < (1f)) {
//			keepDistance ();
//		}

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
			sRendrer.color = Color.white;
			StartCoroutine (flash (0.2f));

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
        Instantiate(enemylazerprefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(WaitTime);
        StartCoroutine(Shoot(r));
        
    }
	
}

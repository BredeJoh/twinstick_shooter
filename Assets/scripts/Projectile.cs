using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private characterMovement player;

	private float spread;
	private float projectileSpeed;
	private float lifetime;
    [HideInInspector]
    public int damage;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<characterMovement> ();

		spread = player.activeWeapon.spread / 100;
		projectileSpeed = player.activeWeapon.projectileSpeed;
		lifetime = player.activeWeapon.projectileLifetime;

		Destroy (gameObject, lifetime);

		Vector3 aimPos = transform.position;

		Vector3 playerPos = player.transform.position;
		aimPos.x -= playerPos.x;
		aimPos.y -= playerPos.y;

		float angle = Mathf.Atan2 (aimPos.y, aimPos.x);
		Debug.Log (angle);
		angle += Random.Range (-spread, spread);
		Debug.Log (angle);

		float xVelocity = projectileSpeed * Mathf.Cos (angle);
		float yVelocity = projectileSpeed * Mathf.Sin (angle);

		Vector3 playerVector = player.GetComponent<Rigidbody2D> ().velocity;

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (xVelocity + ( playerVector.x * 0.75f ), yVelocity + ( playerVector.y * 0.75f ));

	}

	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "enemy")
		{

			Destroy(gameObject);
		}
        other.gameObject.GetComponent<Enemymovement>().health -= damage;

    }
}
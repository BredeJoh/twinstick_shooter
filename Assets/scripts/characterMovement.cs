using UnityEngine;
using System.Collections;

public class characterMovement : MonoBehaviour {
    public float speed = 0f;
    float zRot;
    float angle;
    float rotationspeed = 2.0f;
    public Transform lazerprefab;
    private Rigidbody2D body2D;
    public float force = 0.5f;
    public float maxSpeed = 1f;
    
    

    
	// Use this for initialization
	void Start () {
        body2D = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
        var v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        angle = transform.rotation.eulerAngles.z;
        zRot = Mathf.Deg2Rad*transform.rotation.eulerAngles.z;
        var vel = body2D.velocity;
        speed = vel.magnitude;
        print(speed);
        print(body2D.velocity.x);
        print(body2D.velocity.y);
        
      //  xRot = 
	    
        if (Input.GetKey(KeyCode.UpArrow))
        {
           // Vector3 move = new Vector3 (Mathf.Cos(zRot + (Mathf.PI / 2)), Mathf.Sin(zRot + (Mathf.PI / 2)), 0f);

           // transform.position += move * speed;

         
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + rotationspeed));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - rotationspeed));
        }

        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(lazerprefab, transform.position, transform.rotation);
            }
        }
        if (Input.GetKey(KeyCode.W)  && speed < maxSpeed)
        {
           // body2D.velocity += new Vector2(0, force);
            body2D.AddForce(new Vector2 (0, force), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.S) && speed < maxSpeed)
        {
           // body2D.velocity += new Vector2(0, force*-1);
            body2D.AddForce(new Vector2(0, force*-1), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.D)  && speed < maxSpeed)
        {
          //  body2D.velocity += new Vector2(force, 0);
            body2D.AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A)  && speed < maxSpeed)
        {
          //  body2D.velocity += new Vector2(force*-1, 0);
            body2D.AddForce(new Vector2(force*-1, 0), ForceMode2D.Impulse);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Health.playerHealth--;
        }
        if (other.gameObject.tag == "enemylazer")
        {
            Health.playerHealth--;
        }
        if (Health.playerHealth == 0)
        {
            Destroy(gameObject);
        }
    }
    /*float Rad2Deg(float radianIn)
    {

    }
    float Deg2Rad(float DegreeIn)
    {

    }*/
}

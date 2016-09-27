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
    private bool isShooting = false;
    
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

	    

       /* if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + rotationspeed));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - rotationspeed));
        } */


        float rightvertical = Input.GetAxis("rightJoystickVertical");
        float rightHorizontal = Input.GetAxis("rightJoystickHorizontal");
        float abuttondown = Input.GetAxis("Fire1");
        print(abuttondown);
        if (isShooting == false && abuttondown != 0f && (rightHorizontal != 0f || rightvertical != 0f))
        {
            StartCoroutine(attackAndWait(0.25f));
        }
        
        
        float vertical = Input.GetAxis("vertical");
        float horizontal = Input.GetAxis("horizontal");
        

        if (vertical < -0.2f && speed < maxSpeed)
        {
           // body2D.velocity += new Vector2(0, force);
            body2D.AddForce(new Vector2 (0, force), ForceMode2D.Impulse);
        }
        if (vertical > 0.2f && speed < maxSpeed)
        {
           // body2D.velocity += new Vector2(0, force*-1);
            body2D.AddForce(new Vector2(0, force*-1), ForceMode2D.Impulse);
        }
        if (horizontal > 0.2f && speed < maxSpeed)
        {
          //  body2D.velocity += new Vector2(force, 0);
            body2D.AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
        }
        if (horizontal < -0.2f && speed < maxSpeed)
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
    IEnumerator attackAndWait(float WaitTime)
    {
        isShooting = true;
        Instantiate(lazerprefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(WaitTime);
        isShooting = false;
    }
}
    /*float Rad2Deg(float radianIn)
    {

    }
    float Deg2Rad(float DegreeIn)
    {

    }*/


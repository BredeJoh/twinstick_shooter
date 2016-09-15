using UnityEngine;
using System.Collections;

public class characterMovement : MonoBehaviour {
    public float speed = 0.3f;
    float zRot;
    float angle;
    float rotationspeed = 2.0f;
    public Transform lazerprefab;
    
    

    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        var v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        print(v3);
        // zRot += 1;
        angle = transform.rotation.eulerAngles.z;
        zRot = Mathf.Deg2Rad*transform.rotation.eulerAngles.z;
        
      //  xRot = 
	    
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 move = new Vector3 (Mathf.Cos(zRot + (Mathf.PI / 2)), Mathf.Sin(zRot + (Mathf.PI / 2)), 0f);

            transform.position += move * speed;

         
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(lazerprefab, transform.position, transform.rotation);
            }
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

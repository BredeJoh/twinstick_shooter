using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lazerMovement : MonoBehaviour {

    GameObject body2D;
    public float speed = 1.0f;
    public float zRot;
    Vector3 move;
    GameObject body2D2;
    public float speed2 = 0.1f;
    float angle;
    Vector3 enemyToPlayer;


    // Use this for initialization
    void Start () {
        var v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        enemyToPlayer = new Vector3(0f, 0f, 0f);
        body2D = GameObject.FindGameObjectWithTag("Player");
        enemyToPlayer = v3 - transform.position;
        angle = Mathf.Sqrt((enemyToPlayer.x * enemyToPlayer.x) + (enemyToPlayer.y * enemyToPlayer.y));
        angle = Mathf.Atan2(enemyToPlayer.x, enemyToPlayer.y);
        if (angle < 0)
        {
            angle = Mathf.PI * 2 + angle;
        }
        angle = (angle * 360) / (Mathf.PI * 2);
        angle = 360 - angle;
        transform.eulerAngles = new Vector3(0f, 0f, angle);

    }
	
	// Update is called once per frame
	void Update () {

        
        //transform.position += move * speed;
        transform.position += enemyToPlayer.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Points.score++;
            Destroy(gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            Destroy(gameObject);
        }
    }
}

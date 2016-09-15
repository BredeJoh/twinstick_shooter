using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    Text txt;
    public static int playerHealth = 5;
    // Use this for initialization
    void Start () {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Health : " + playerHealth;
    }
	
	// Update is called once per frame
	void Update () {
        txt.text = "Health : " + playerHealth;
    }
}

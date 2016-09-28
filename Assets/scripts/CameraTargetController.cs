using UnityEngine;
using System.Collections;

public class CameraTargetController : MonoBehaviour {

	public GameObject player;

	public float maxCameraDistance;

	Vector3 mousePos;
	Vector3 worldPos;

	// Use this for initialization
	void Start () {
	
		//player = FindObjectOfType<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
	
		//Track Mouse Position
		mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);

		//Mouse Position compared to Player Avatar
		Vector3 pPos = player.gameObject.transform.position;
		mousePos.Set (mousePos.x - pPos.x, mousePos.y - pPos.y, -10);

		float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		float dist = Mathf.Sqrt (Mathf.Pow (mousePos.x, 2) + Mathf.Pow (mousePos.y, 2));

		//if (dist > maxCameraDistance)
		//	dist = maxCameraDistance;

		float distx = dist * Mathf.Cos (angle * Mathf.Deg2Rad);
		float disty = dist * Mathf.Sin (angle * Mathf.Deg2Rad);

		Vector3 temp = new Vector3(distx, disty, -10);

		//Move Camera Target
		transform.position = player.transform.position + temp / 2;
		Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, transform.position, 1f);

	}
}

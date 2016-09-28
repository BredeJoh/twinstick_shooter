using UnityEngine;
using System.Collections;

public class CameraTargetController : MonoBehaviour {

	public GameObject player;
	public float maxCameraDistance;
	public float cameraSpeed;

	Vector3 mousePos;
	Vector3 worldPos;

	bool inputType;
	static bool JOYSTICK = true;
	static bool MOUSE = false;

	// Use this for initialization
	void Start () {

		inputType = JOYSTICK;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Tab))
			inputType = !inputType;
		
	}

	void FixedUpdate () {

		Vector3 playerPos = player.transform.position;

		if (inputType == MOUSE) {

			//Track Mouse Position
			mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint (mousePos);

			//Mouse Position compared to Player Avatar
			Vector3 cameraPos = Camera.main.transform.position;
			mousePos.Set (mousePos.x - cameraPos.x, mousePos.y - cameraPos.y, -10);

			float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
			float dist = Mathf.Sqrt (Mathf.Pow (mousePos.x, 2) + Mathf.Pow (mousePos.y, 2));

			float distx = dist * Mathf.Cos (angle * Mathf.Deg2Rad);
			float disty = dist * Mathf.Sin (angle * Mathf.Deg2Rad);

			Vector3 temp = new Vector3 (distx, disty, -10);

			//Move Camera Target
			transform.position = new Vector3(playerPos.x + temp.x / 4, playerPos.y + temp.y / 4, -10);

		} else {
			
			//Controller
			float joyVertical = Input.GetAxis ("rightJoystickVertical");
			float joyHorizontal = Input.GetAxis ("rightJoystickHorizontal");

			transform.position = new Vector3 (playerPos.x + maxCameraDistance * joyHorizontal, playerPos.y + maxCameraDistance * -joyVertical, -10);
		}

		Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, transform.position, cameraSpeed * Time.deltaTime);
	}
		
}

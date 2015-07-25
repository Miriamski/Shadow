using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	public bool HideAnimation = true;
	
	private Vector3 offset;
	private Camera cam;
	private int oldMask;
	
	void Start ()
	{
		cam = GetComponent<Camera> ();
		oldMask = cam.cullingMask;
		offset = transform.position - player.transform.position;
	}
	
	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
		var playerState = player.GetComponent<PlayerController> ().state;

		if (HideAnimation && playerState == PlayerController.State.Hiding) {
			//transform.Rotate (Vector3.forward * Time.deltaTime * 40);
			cam.cullingMask = (1 << LayerMask.NameToLayer ("Player")) | (1 << LayerMask.NameToLayer("Black"));


		} else {
			cam.cullingMask = oldMask;
		}

		if (transform.eulerAngles != new Vector3 (0,0,0) && playerState != PlayerController.State.Hiding)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}

	}
}
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

		if (HideAnimation && player.GetComponent<PlayerController> ().isHiding) {
			//transform.Rotate (Vector3.forward * Time.deltaTime * 40);
			cam.cullingMask = (1 << LayerMask.NameToLayer ("Player")) | (1 << LayerMask.NameToLayer("Black"));


		} else {
			cam.cullingMask = oldMask;
		}

		if (transform.eulerAngles != new Vector3 (0,0,0) && !player.GetComponent<PlayerController> ().isHiding) 
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}

	}
}
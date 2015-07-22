using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	public GameObject player;

	void OnTriggerEnter2D( Collider2D invader)
	{
		if( invader.gameObject.CompareTag("Player"))
		{
			player.GetComponent<PlayerController> ().dead = true;
		}
	}
}

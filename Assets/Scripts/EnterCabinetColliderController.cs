using UnityEngine;
using System.Collections;

public class EnterCabinetColliderController : MonoBehaviour 
{
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D invader)
    {
        //print(invader.tag);
        if (invader.CompareTag("Player"))
        {
            player.GetComponent<PlayerEntersCabinetBehaviour>().SetInReach(true);

        }
    }

    void OnTriggerExit2D(Collider2D invader)
    {
        if (invader.CompareTag("Player"))
        {

            player.GetComponent<PlayerEntersCabinetBehaviour>().SetInReach(false);
        }
    }
}

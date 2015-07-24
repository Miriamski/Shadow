using UnityEngine;
using System.Collections;

public class EnterCabinetColliderController : MonoBehaviour 
{
    public GameObject player;
    //private MonoBehaviour playerBehaveiour;
    public Animator animator;

	// Use this for initialization
	void Awake ()
	{
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Animate();
	}

    private void Animate()
    {
        if (player.GetComponent<PlayerEntersCabinetBehaviour>().GetTimetraveling())
        {
            animator.SetBool("isOpen",false);
        }
    }

    void OnTriggerEnter2D(Collider2D invader)
    {
        //print(invader.tag);
        if (invader.CompareTag("Player"))
        {
            player.GetComponent<PlayerEntersCabinetBehaviour>().SetInReach(true);

            //if (player.GetComponent<PlayerEntersCabinetBehaviour>().timetraveling)
            //{
            //    Vector3 newPosition = player.transform.position;
            //    newPosition.y = (gameObject.transform.position.y - (gameObject.GetComponent<BoxCollider2D>().size.y) / 2);
            //    player.transform.position = newPosition;
            //}

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

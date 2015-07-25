using UnityEngine;
using System.Collections;

public class PlayerEntersCabinetBehaviour : MonoBehaviour
{
    [HideInInspector] public bool timetraveling;
    private bool inReach;

    public Animator animator;
    
    // Use this for initialization
    void Start()
    {
        timetraveling = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (inReach) 
				timetraveling = true;
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			timetraveling = false;
			gameObject.GetComponent<PlayerController>().stopTravelingTime();
		}
        //print(timetraveling);
    }

    void FixedUpdate()
    {
        Animate();
    }

    void OnTriggerStay2D(Collider2D invaded)
    {
        if (invaded.CompareTag ("TimeCabinetCollider") && timetraveling) {
			Vector3 newPosition = gameObject.transform.position;
			newPosition.y = invaded.transform.position.y 
				- (invaded.GetComponent<BoxCollider2D> ().size.y) / 2f
				+ (gameObject.GetComponent<BoxCollider2D> ().size.y) * 0.8f;
			// print(newPosition.y);
			gameObject.transform.position = newPosition;
			gameObject.GetComponent<PlayerController>().travelTime();
		}
    }

    private void Animate()
    {
        if(timetraveling)
        {
            //animator.Play("Enter Cabinet");
        }
    }

    public bool GetInReach()
    {
        return inReach;
    }

    public void SetInReach(bool isInReach)
    {
        inReach = isInReach;
    }

    public bool GetTimetraveling()
    {
        return timetraveling;
    }

}

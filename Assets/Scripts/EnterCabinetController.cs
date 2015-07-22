using UnityEngine;
using System.Collections;

public class EnterCabinetController : MonoBehaviour
{

    [HideInInspector] public bool isTimetraveling;
     [HideInInspector] private bool isInReach;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D( Collider2D invader)
    {
        if( invader.gameObject.CompareTag("Player"))
        {
            isInReach = true;
        }
    }
}

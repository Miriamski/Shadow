using UnityEngine;
using System.Collections;

public class PlayerEntersCabinetController : MonoBehaviour
{
    //[HideInInspector]
    public bool isTimetraveling;
    //[HideInInspector]
    public bool isInReach;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collider2D invaded)
    {
        if (invaded.gameObject.CompareTag("TimeCabinet"))
        {
            isInReach = true;
        }
    }

    void OnCollisionExit2D(Collider2D invaded)
    {
        if (invaded.gameObject.CompareTag("TimeCabinet"))
        {
            isInReach = false;
        }
    }
}

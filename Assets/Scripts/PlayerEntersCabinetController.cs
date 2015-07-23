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
        print(isInReach);
    }


}

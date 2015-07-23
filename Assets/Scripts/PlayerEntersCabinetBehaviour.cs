using UnityEngine;
using System.Collections;

public class PlayerEntersCabinetBehaviour : MonoBehaviour
{
    private bool timetraveling;
    private bool inReach;

    public Animator animator;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timetraveling = ((Input.GetAxis("Vertical") > 0) && inReach);
        print(timetraveling);
    }

    void FixedUpdate()
    {
        Animate();
    }

    private void Animate()
    {
        if(timetraveling)
        {
            animator.SetBool("Timetraveling", true);
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

}

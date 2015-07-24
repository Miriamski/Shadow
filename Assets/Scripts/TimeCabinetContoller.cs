using UnityEngine;
using System.Collections;

public class TimeCabinetContoller : MonoBehaviour
{
    [HideInInspector] public bool isOpen = false;
    public Animator animator;
    public float stepSize; 

    void OnTriggerEnter2D ( Collider2D invader)
    {
        if (invader.gameObject.CompareTag("Player"))
        {
            isOpen = true;
        }
    }

    void OnTriggerExit2D ( Collider2D invader)
    {
        if (invader.gameObject.CompareTag("Player"))
        {
            isOpen = false;
        }
    }

    void FixedUpdate ()
    {
        animate();
    }

    void animate()
    {
        animator.SetBool("isOpen", isOpen);
    }


}

using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour
{
    private Animator animator;
    private GameObject player;
    private SpriteRenderer renderer;
    private bool inReach;

    void Start()
    {
        player = GetComponentInParent<EnterCabinetColliderController>().player;
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = false;
        inReach = false;
    }

    void Update()
    {
        inReach = player.GetComponent<PlayerEntersCabinetBehaviour>().GetInReach();
        if(inReach)
        {
            renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }
    }
    
    void FixedUpdate()
    {
        Animate();
    }

    private void Animate()
    {
        animator.SetBool("inReach",inReach);
    }
}

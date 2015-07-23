using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour
{
    private Animator animator;
    private GameObject player;
    private SpriteRenderer arrowSpriteRenderer;
    private bool inReach;

    void Awake()
    {
        player = GetComponentInParent<EnterCabinetColliderController>().player;
        animator = GetComponent<Animator>();
        arrowSpriteRenderer = GetComponent<SpriteRenderer>();
        arrowSpriteRenderer.enabled = false;
        inReach = false;
    }

    void Update()
    {
        inReach = player.GetComponent<PlayerEntersCabinetBehaviour>().GetInReach();
        if(inReach)
        {
            arrowSpriteRenderer.enabled = true;
        }
        else
        {
            arrowSpriteRenderer.enabled = false;
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

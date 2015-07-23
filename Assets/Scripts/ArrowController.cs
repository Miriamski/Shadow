using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour
{
    private Animator animator;
    private GameObject player;
    private bool inReach;

    void Start()
    {
        player = GetComponentInParent<EnterCabinetColliderController>().player;
        animator = GetComponent<Animator>();
        inReach = false;
    }

    void Update()
    {
        inReach = player.GetComponent<PlayerEntersCabinetBehaviour>().GetInReach();
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

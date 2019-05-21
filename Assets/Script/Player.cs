using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //bool to check whether or not players are participating in a minigame
    public bool playingMinigame;

    public bool interacting;

    //Navigation agent
    NavMeshAgent myNav;

    Animator anim;

    void Start()
    {
        //Get the navigation agent property of the player
        myNav = GetComponent<NavMeshAgent>();
        playingMinigame = false;
        interacting = false;
        //get the animator of the player
        anim = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        //Call the function controller if not playing minigame
        if (!playingMinigame)
        {
            Controller();
        }
    }

    void Controller()
    {
        if (!playingMinigame && !interacting)
        {
            //Check for keys being pressed
            if (Input.GetKey(KeyCode.W))
            {
                //Make the player move to the navigetor destination.
                myNav.SetDestination(transform.position + Vector3.forward);

                //change the value of the state of the animation so it changes
                anim.SetInteger("state", 1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                myNav.SetDestination(transform.position + Vector3.left);
                anim.SetInteger("state", 1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                myNav.SetDestination(transform.position + Vector3.back);
                anim.SetInteger("state", 1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                myNav.SetDestination(transform.position + Vector3.right);
                anim.SetInteger("state", 1);
            }

            //If non of the keys are being pressed, make the new destination the player position so it doesn't move.
            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
            {
                myNav.SetDestination(transform.position);
                //stop walking
                anim.SetInteger("state", 0);
            }
        }
    }
}

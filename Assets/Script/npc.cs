using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    //get the player transfrom through the inspector
    public Transform player;

    public GameObject interaction;

    void OnTriggerStay()
    {
        //once the player stays within the trigger the npc will lock it vision on to it.
        transform.LookAt(player.position);

        if (Input.GetKeyDown(KeyCode.F))
        {
            //opens the npc interactive screen
            interaction.SetActive(true);

            //prevent player from moving while interacting with the npc
            player.GetComponent<Player>().interacting = true;
        }
    }

    //public methods to access from the buttons
    //Challenge the npc
    public void Challenge()
    {
        //start the minigame
        player.GetComponent<Player>().playingMinigame = true;

        //close the npc interactive screen
        interaction.SetActive(false);
    }

    //dont challenge the npc
    public void Pass()
    {
        //closes the npc interactive screen
        interaction.SetActive(false);

        //allow players to move after interacting with the npc
        player.GetComponent<Player>().interacting = false;
    }
}

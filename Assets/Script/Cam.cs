using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    //Get the player GameObject throught the inspector
    public GameObject player;

    //Public Vector3 to manually set the fixed position in the inspector.
    public Vector3 addToPlayerPos;

    //fixed position to play minigames
    public Transform miniGamePos;

    //look at target during the minigame
    public Transform miniGameTarget;

    //bullet game object
    public GameObject bullet;

    Vector3 fixedPos;

    void Update()
    {
        //check if the minigame is being played
        if (player.GetComponent<Player>().playingMinigame)
        {
            //move the camera to a new position design for the minigame
            transform.position = miniGamePos.position;
            
            //lock camera on to the target
            transform.LookAt(miniGameTarget.position);

            //call the function playgame
            PlayGame();
        }

        //do this if its not
        else
        {
            //fixed position updates with the player position
            fixedPos = player.transform.position + addToPlayerPos;

            //Use lerp to create a delay between the camera position and the new fixed position based on the player position
            transform.position = Vector3.Lerp(transform.position, fixedPos, 0.125f);

            //Keep the camera locked on to the player
            transform.LookAt(player.transform.position);
        }
    }

    void PlayGame()
    {
        //get left click pushed down
        if (Input.GetButtonDown("Fire1"))
        {
            //ray cast with the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //local game object that serves to register the bullet and turn it active
            GameObject makeupBullet;

            //spawn a new bullet
            makeupBullet = Instantiate(bullet, transform.position + (Vector3.up * 2), Quaternion.identity);

            //set the new bullet as active game object
            makeupBullet.SetActive(true);

            //use the mouse position to set a direction to shoot
            makeupBullet.GetComponent<Rigidbody>().AddForce(ray.direction * 25, ForceMode.Impulse);
        }
    }
}

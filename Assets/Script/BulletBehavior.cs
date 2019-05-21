using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public GameObject target;

    public GameObject winScreen;

    public GameObject player;

    void Update ()
    {
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("target"))
        {
            //change the color of the target when hit by the make up ball
            other.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            winScreen.SetActive(true);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NoThanks()
    {
        winScreen.SetActive(false);
        player.GetComponent<Player>().playingMinigame = false;
        player.GetComponent<Player>().interacting = false;
        target.GetComponent<Renderer>().material.color = Color.white;
    }

    public void ReMatch()
    {
        winScreen.SetActive(false);
        target.GetComponent<Renderer>().material.color = Color.white;
    }
}

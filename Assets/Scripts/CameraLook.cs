using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        // Gets the player doughnut
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }

    // Rotates the camera to look at the player
    void LookAtPlayer()
    {
        // Makes a triangle with the player and the camera and uses atan to find the angle that the camera needs to have in order to look at the player
        // a is the side on the z axis, and b is the side on the x axis

        float a = transform.position.z - player.transform.position.z;
        float b = transform.position.x - player.transform.position.x;
        float angle = Mathf.Atan2(-a, b);

        // Makes the camera look the player
        transform.rotation = Quaternion.Euler(0, angle * Mathf.Rad2Deg - 90, 0);
    }
}

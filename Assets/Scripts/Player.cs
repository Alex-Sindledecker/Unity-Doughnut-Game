using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Game game;
    private float health = 100;
    private float timeSurvived = 0;
    private bool dead = false;

    public Rigidbody rb; // Player rigid body
    public float speed = 100; // Force applyed to the player
    public float Health => health;
    public float TimeSurvived => (float)Math.Round(timeSurvived, 2);

    public event Action OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0 || transform.position.y < -20 && OnDeath != null)
        {
            dead = true;
            OnDeath();
        }
    }

    void FixedUpdate()
    {
        if (!dead)
        {
            // Applys forces to move the player
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(-speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            timeSurvived += Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plate" && !dead)
        {
            float mag = collision.relativeVelocity.magnitude;
            health = Mathf.Round(health - mag);
            if (health < 0)
                health = 0;
        }
    }
}

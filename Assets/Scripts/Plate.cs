using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public float lifeInSeconds = 5;

    private float startTime;
    private Renderer renderer;
    private Game game;

    void Start()
    {
        startTime = Time.time;
        renderer = gameObject.GetComponent<Renderer>();
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > lifeInSeconds - 1)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Color color = renderer.material.color;
            renderer.material.color = new Color(color.r, color.g, color.b, color.a - Time.deltaTime);
        }
        if (Time.time - startTime > lifeInSeconds)
            Destroy(gameObject);
    }
}

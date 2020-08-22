using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject mobPreFab;

    public event Action OnQuitGame;

    private float spawnFrequency = 1f;
    private float lastSpawnTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float spawnTime = Time.time;
        if (spawnTime - lastSpawnTime > spawnFrequency)
        {
            Vector3 pos = new Vector3(UnityEngine.Random.Range(-15, 15), 10, mobPreFab.transform.position.z);
            GameObject mob = Instantiate(mobPreFab, pos, Quaternion.Euler(0, 180, UnityEngine.Random.Range(0, 359)));
            lastSpawnTime = spawnTime;
        }
    }

    public void PlayAgainButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitButtonPressed()
    {
        if (OnQuitGame != null)
        {
            OnQuitGame();
        }
        Application.Quit();
    }
}

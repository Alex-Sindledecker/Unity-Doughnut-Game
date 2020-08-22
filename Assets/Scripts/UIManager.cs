using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public Text healthText;
    public Text lifeTimeText;
    public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        player.OnDeath += DisplayDeathScreen;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.Health.ToString() + "%";
        lifeTimeText.text = "Time Survived: " + player.TimeSurvived.ToString() + "s";
    }

    private void DisplayDeathScreen()
    {
        deathScreen.SetActive(true);
    }
}

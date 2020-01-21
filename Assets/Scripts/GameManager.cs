using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text gameTimerText;
    public Text gameOverText;
    public Text player1Score;
    public Text player2Score;
    public GameObject spawn;
    private float gameTimer;

    // Start is called before the first frame update
    void Start()
    {
        //Screen.SetResolution(1024, 768, true);
        gameOverText.text = "";
        gameTimer = 30;
        gameTimerText.text = Mathf.Floor(gameTimer).ToString();
        Time.timeScale = 0;
        Instantiate(spawn);
        Instantiate(spawn);
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        gameTimerText.text = Mathf.Floor(gameTimer).ToString();

        if(Time.timeScale == 0)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if(gameTimer <= 0)
        {
            if(int.Parse(player1Score.text) > int.Parse(player2Score.text))
                gameOverText.text = "Player 1 Wins!";
            else
                gameOverText.text = "Player 2 Wins!";

            if(int.Parse(player1Score.text) == int.Parse(player2Score.text))
            {
                gameOverText.text = "Tie Game!";
            }

            Time.timeScale = 0;
            gameTimerText.text = "0";
        }
    }

    public void Spawn()
    {
        Instantiate(spawn);
    }
}

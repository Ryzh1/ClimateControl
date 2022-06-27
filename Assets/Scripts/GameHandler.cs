using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    private GameObject player;
    private GameObject camp;
    private Player_Controller Player;
    private Camp_Controller Camp;

    public UI MainUI;
    private GameObject endUI;
    private GameObject levelUI;


    public TextMeshProUGUI endText;
    public TextMeshProUGUI finalScoreText;
    public float finalScore;
    

    private bool gameOver;



    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        camp = GameObject.Find("Camp");
        player = GameObject.Find("Player");
        Player = player.GetComponent<Player_Controller>();
        Camp = camp.GetComponent<Camp_Controller>();
        
        endUI = GameObject.Find("End UI");
        levelUI = GameObject.Find("Level UI");

        gameOver = false;

        
        endUI.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        if(Player.CurrentHealth <= 0 && !gameOver)
        {
            GameEnd("PlayerDied");

            gameOver = true;
        }
        else if(Camp.campCurrentHealth <= 0 && !gameOver)
        {
            GameEnd("FamilyDied");
            gameOver = true;
        }

    }


    public void GameEnd(string Outcome)
    {
        finalScore = MainUI.ScoreAmount;
        endUI.SetActive(true);
        levelUI.SetActive(false);
        if (Outcome == "PlayerDied")
        {
            endText.text = "GameOver You Died!";
            Over();
        }
        else if (Outcome == "FamilyDied")
        {
            endText.text = "GameOver Your Family Died!";
            Over();

        }
    }

    void Over()
    {
        SceneManager.LoadScene("End Game");       
        finalScoreText.text = "Final Score: " + Mathf.Round(finalScore);
        StartCoroutine(StartPause());

    }

    IEnumerator StartPause()
    {
        yield return new WaitForSeconds(5);
        endUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}

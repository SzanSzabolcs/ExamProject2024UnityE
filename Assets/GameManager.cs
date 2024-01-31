using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

class GameManager : MonoBehaviour

{
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] int lives = 3; // Kezdeti �letek sz�ma

    [SerializeField] Image Live03;
    [SerializeField] Image Live02;
    [SerializeField] Image Live01;
    [SerializeField] GameObject gameOverObject;
    [SerializeField] GameObject Demon;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject Credits;


    void Start()
    {
        UpdateLivesUI();
        UpdateScoreUI();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }

    public void MainmenuGame()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1f;
    }

    public void CreditsGame()
    {
        Demon.SetActive(false);
        Canvas.SetActive(false);
        Credits.SetActive(true);
    }

    public void CreditsOffGame()
    {
        Demon.SetActive(true);
        Canvas.SetActive(true);
        Credits.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        //GAME OVER SCREEN ON
        gameOverObject.SetActive(true);
    }

    public void GameQuit()
    {
        // J�t�k le�ll�t�sa
        Application.Quit();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreUI();

        // Ellen�rizz�k, hogy el�rt�k-e a 100 pontot
        if (score == 100)
        {
            // Hozz�adjuk a plusz �letet
            IncreaseLives();
        }
    }

    void IncreaseLives()
    {
        // Ellen�rizz�k, hogy az �letek ne legyenek t�bb mint 3
        if (lives < 3)
        {
            lives++;
            UpdateLivesUI();
        }
    }

    // �letek cs�kkent�se
    public void DecreaseLives()
    {
        lives--;

        // Friss�tj�k az �letk�peket a Canvas-en
        UpdateLivesUI();

        if (lives <= 0)
        {
            // Ha elfogytak az �letek, j�t�k v�ge
            GameOver();
        }
    }

    // UI friss�t�se a jelenlegi �letekkel
    public void UpdateLivesUI()
    {
        // Ellen�rizz�k, hogy a k�pek ne null legyenek, �s ha nem, akkor friss�tj�k azokat
        if (Live03 != null && Live02 != null && Live01 != null)
        {
            // Friss�tj�k az �letk�peket a Canvas-en
            switch (lives)
            {
                case 3:
                    Live03.color = Color.white;
                    Live02.color = Color.white;
                    Live01.color = Color.white;
                    break;
                case 2:
                    Live03.color = Color.black;
                    Live02.color = Color.white;
                    Live01.color = Color.white;
                    break;
                case 1:
                    Live03.color = Color.black;
                    Live02.color = Color.black;
                    Live01.color = Color.white;
                    break;
                default:
                    Live03.color = Color.black;
                    Live02.color = Color.black;
                    Live01.color = Color.black;
                    break;
            }
        }
        else
        {
            Debug.LogError("One or more live images are null! Make sure they are assigned in the Inspector.");
        }
    }

    void UpdateScoreUI()
    {
        // Ellen�rizz�k, hogy a scoreText ne null legyen, �s ha nem, akkor friss�tj�k a sz�veget
        if (scoreText != null)
        {
            // A sz�veget friss�tj�k a jelenlegi pontsz�mmal
            scoreText.text = "SCORE: " + score.ToString("D3");
        }
    }
}


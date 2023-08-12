using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Camera gameCamera;
    public Button restartButton;
    public AudioSource hitSound;

    private int score;

    // Start is called before the first frame update
    private void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score").ToString();
    }

    // add points to the score
    public void addScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        hitSound.Play();
    }

    // return the current score
    public int getScore() { return score; }

    // reload the scene
    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // set the background to red and save the high score
    public void endGame()
    {
        gameCamera.backgroundColor = Color.red;
        restartButton.gameObject.SetActive(true);

        if (score > PlayerPrefs.GetInt("High Score"))
        {
            PlayerPrefs.SetInt("High Score", score);
            PlayerPrefs.Save();
        }
    }
}

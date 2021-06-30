using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//UI object logic 
public class RestartPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject restartPanel;
    public GameObject startPanel;
    public Text playerHealth;
    public Text scoreText;
    public Text welocomeText;
    public static int _playerDead;
    public static int _score;

    void Start()
    {
        _playerDead = 3;
        _score = 0;
        StartCoroutine(ShowText());
    }

    private void Update()
    {
        if (_playerDead<=0)
        {
            restartPanel.SetActive(true);
            Time.timeScale = 0;
        }

        playerHealth.text = "Health player = " + _playerDead ;
        scoreText.text = _score + "";
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        startPanel.SetActive(false);
        Instantiate(player, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Time.timeScale = 1;
    }

    private string fullText = "The main aim of the game is to shoot down asteroids and stay out of their way." +
        " You can control the ship using the 'W', 'A', 'S', 'D' keys, or the left right up-down keys. Enjoy the game! ";
    private string currentText = "";

    IEnumerator ShowText()
    {

        for (int i = 0; i <= fullText.Length; i++)
        {
           
            yield return null;
            welocomeText.text = currentText;

            currentText = fullText.Substring(0, i);

            yield return new WaitForSeconds(0.06f);
        }


    }
}

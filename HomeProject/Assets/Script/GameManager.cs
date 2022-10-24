using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public TMP_Text timeText;
    public TMP_Text highScore;

    float survieTime;
    bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        survieTime = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            survieTime += Time.deltaTime;
            timeText.text = "Time : " + (int)survieTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Dodge");
            }
        }
    }
    public void EndGame()
    {
        isGameOver = true;

        gameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (survieTime > bestTime)
        {
            bestTime = survieTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        highScore.text = "Best Time : " + (int)bestTime;
    }
}

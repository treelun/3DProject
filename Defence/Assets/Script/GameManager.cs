using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject menuCamera;

    public GameObject enemySpawnPoint;
    public GameObject playerSpawnPoint;

    public GameObject titleMenu;
    public GameObject MouseCon;

    public void GameStart()
    {
        menuCamera.SetActive(false);
        mainCamera.SetActive(true);

        titleMenu.SetActive(false);

        enemySpawnPoint.SetActive(true);
        playerSpawnPoint.SetActive(true);
        MouseCon.SetActive(true);
    }
    public void GameExit()
    {
        Application.Quit();
    }
}

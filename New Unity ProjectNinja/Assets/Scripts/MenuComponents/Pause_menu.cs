using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_menu : MonoBehaviour
{
    public static bool gameIspaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(gameIspaused) 
            {
                Resume();
            }
            else 
            {
                PauseMeny();
            }
        }
        
    }

    private void PauseMeny()
    {
        // cause menu
        pauseMenuUI.SetActive(true );

        //stap game process
        Time.timeScale = 0f;
        gameIspaused = true;
    }

    public  void Resume()
    {
        pauseMenuUI.SetActive(false);  
        Time.timeScale = 1f;
        gameIspaused = false;

    }

    public void LoadMenu() 
    {
        Debug.Log("Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            mainMenu.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        mainMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

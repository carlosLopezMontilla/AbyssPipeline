using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioSource menuTheme;
    void Start()
    {
        menuTheme.Play();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        menuTheme.Stop();
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Saliendo de la aplicacion...");
    }
}

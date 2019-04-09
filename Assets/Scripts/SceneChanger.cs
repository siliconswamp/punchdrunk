using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneSelector(string scene)
    {
        if (scene.Equals("main"))
        {
            SceneManager.LoadScene("MAIN");
        }

        if (scene.Equals("play"))
        {
            SceneManager.LoadScene("FIGHT");
        }

        if (scene.Equals("exit"))
        {
            Application.Quit();
        }
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MAIN");
    }

    public void battle()
    {
        SceneManager.LoadScene("FIGHT");
    }

    public void lose()
    {
        Debug.Log("Player Lost Scene");
        SceneManager.LoadScene("LOSE");
    }

    public void win()
    {
        SceneManager.LoadScene("WIN");
    }

    public void quit()
    {
        Application.Quit();
    }
}

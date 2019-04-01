using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
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

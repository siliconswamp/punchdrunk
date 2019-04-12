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

        if (scene.Equals("instruct"))
        {
            SceneManager.LoadScene("INSTRUCT");
        }

        if (scene.Equals("character"))
        {
            SceneManager.LoadScene("CHARSELECT");
        }

        if (scene.Equals("feat"))
        {
            SceneManager.LoadScene("TROPHY");
        }

        if (scene.Equals("round2"))
        {
            SceneManager.LoadScene("FIGHT2");
        }

        if (scene.Equals("round3"))
        {
            SceneManager.LoadScene("FIGHT3");
        }
        

        if (scene.Equals("exit"))
        {
            //Works in editor only
            //UnityEditor.EditorApplication.isPlaying = false;
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

    public void help()
    {
        SceneManager.LoadScene("INSTRUCT");
    }

    public void charsel()
    {
        SceneManager.LoadScene("CHARSELECT");
    }

    public void achieve()
    {
        SceneManager.LoadScene("TROPHY");
    }

    public void lose()
    {
        Debug.Log("Player Lost Scene");
        SceneManager.LoadScene("LOSE");
    }

    public void win()
    {
        Debug.Log("Player Won Scene");
        SceneManager.LoadScene("WIN");
    }

    public void quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour
{
    public SceneChanger scene;
    public Button game, exit;

    void Start()
    {
        select();
    }

    void select()
    {
        game.onClick.AddListener(goToMatch);
        exit.onClick.AddListener(exitGame);
    }

    void goToMatch()
    {
        scene.battle();
    }

    void exitGame()
    {
        scene.quit();
    }
}

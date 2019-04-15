using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToMenu : MonoBehaviour
{
    private SceneChanger scene;
    public Button menu;

    void Start()
    {
        select();
    }

    void select()
    {
        menu.onClick.AddListener(goToMenu);
    }

    void goToMenu()
    {
        //scene.mainMenu();
    }
}

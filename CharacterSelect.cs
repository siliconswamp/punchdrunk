using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{

    public SceneChanger scene;
    public populateUI popUI;
    public Button p1b, p2b;
    public bool p1, p2;
    // Start is called before the first frame update
    void Start()
    {
        if (charSelectAvailable() != true)
        {
            p1 = GlobalControl.Instance.p1;
            p2 = GlobalControl.Instance.p2;
            p1 = true;
            p2 = false;
            p2b.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool charSelectAvailable()
    {
        if ((GlobalControl.Instance.array[0, 0] == true) && (GlobalControl.Instance.array[0, 1] == true) && (GlobalControl.Instance.array[0, 2] == true))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void playerSelect(int player)
    {
        if (player == 1)
        {
            p1 = true;
            p2 = false;
            scene.battle();
        }

        else if (player == 2)
        {
            p2 = true;
            p1 = false;
            scene.battle2();
        }

        else if (player == 3) {
            scene.mainMenu();
        }

        GlobalControl.Instance.p1 = p1;
        GlobalControl.Instance.p2 = p2;
    }
}

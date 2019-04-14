using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public bool[,] array = new bool[2, 3];
    public string nextRound;
    public bool p1, p2;
    public static GlobalControl Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}

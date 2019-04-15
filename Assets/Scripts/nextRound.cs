using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextRound : MonoBehaviour
{
    public SceneChanger SC;
    public Button next;
    public Text update;

    void Start()
    {
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText()
    {
        if (GlobalControl.Instance.nextRound == "f2")
        {
            update.text = "Complements! As Hawking, you have beaten Katie Bouman, \n an imaging scientist responsible for the first picture of a black hole.";
        }

        if (GlobalControl.Instance.nextRound == "f3")
        {
            update.text = "Complements! As Hawking, you have beaten Karl Schwarzschild, known for \n providing the first exact solution to Einstein's field equations of \n general relativity and generating many original concepts that \n now bear his name, including Schwarzschild black holes.";
        }

        if (GlobalControl.Instance.nextRound == "f22")
        {
            update.text = "Complements! As Einstein, you have beaten Katie Bouman, \n an imaging scientist responsible for the first picture of a black hole.";
        }

        if (GlobalControl.Instance.nextRound == "f23")
        {
            update.text = "Complements! As Einstein, you have beaten Karl Schwarzschild, known for \n providing the first exact solution to Einstein's field equations of \n general relativity and generating many original concepts that \n now bear his name, including Schwarzschild black holes.";
        }

        if (GlobalControl.Instance.nextRound == "main")
        {
            if (GlobalControl.Instance.p1 == true)
            {
                update.text = "You have beaten Event Horizon as Stephen Hawking, a theoretical physicist \n known for his contributions to the fields of cosmology, general relativity, \n and quantum gravity, especially in the context of black holes.";
            }
            else
            {
                update.text = "You have beaten Event Horizon as Albert Einstein, a theoretical physicist known \n for his General Theory of Relativity and the concept of mass-energy equivalence, \n expressed famously as the equation, E=mc^2.";
            }
            next.enabled = false;
        }
    }

    public void nR()
    {
        if (GlobalControl.Instance.nextRound == "f2")
        {
            SC.SceneSelector("round2");
        }

        if (GlobalControl.Instance.nextRound == "f3")
        {
            SC.SceneSelector("round3");
        }

        if (GlobalControl.Instance.nextRound == "f22")
        {
            SC.SceneSelector("2round2");
        }

        if (GlobalControl.Instance.nextRound == "f23")
        {
            SC.SceneSelector("2round3");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextRound : MonoBehaviour
{
    public SceneChanger SC;
    public Button next;
    public Text update, update2;

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
            update2.text = "";
            update.text = "As Hawking, you have beaten Katie Bouman, \n an imaging scientist responsible for the first picture \n of a black hole.";
        }

        if (GlobalControl.Instance.nextRound == "f3")
        {
            update2.text = "";
            update.text = "As Hawking, you have beaten Karl Schwarzschild,\n known for providing the first exact solution to \n Einstein's field equations of general relativity and \n generating many original concepts that now bear his name, \n including Schwarzschild black holes.";
        }

        if (GlobalControl.Instance.nextRound == "f22")
        {
            update2.text = "";
            update.text = "As Einstein, you have beaten Katie Bouman, \n an imaging scientist responsible for the first picture \n of a black hole.";
        }

        if (GlobalControl.Instance.nextRound == "f23")
        {
            update2.text = "";
            update.text = "As Einstein, you have beaten Karl Schwarzschild,\n known for providing the first exact solution to \n Einstein's field equations of general relativity and \n generating many original concepts that now bear his name, \n including Schwarzschild black holes.";
        }

        if (GlobalControl.Instance.nextRound == "main")
        {
            if (GlobalControl.Instance.p1 == true)
            {
                update2.text = "If I have seen further, \n it is by standing upon the shoulders of giants. \n \n -Sir Isaac Newton";
                update.text = "You have beaten Sir Isaac Newton, \n most famous for his work on forces, \n specifically gravity. \n \n Thus, you prevail over Event Horizon as Stephen Hawking, \n a theoretical physicist known \n for his contributions to the fields of cosmology, \n general relativity, and quantum gravity, \n especially in the context of black holes.";
            }
            else
            {
                update.text = "You have beaten Sir Isaac Newton, \n most famous for his work on forces, \n specifically gravity. \n \n Thus, you prevail over Event Horizon as Albert Einstein, \n a theoretical physicist known for his General Theory \n of Relativity and the concept of mass energy \n equivalence, expressed famously as the equation, \n E=mc^2";
                update2.text = "If I have seen further, \n it is by standing upon the shoulders of giants. \n \n -Sir Isaac Newton";
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

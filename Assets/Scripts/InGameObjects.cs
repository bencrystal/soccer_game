using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InGameObjects : MonoBehaviour
{

    public Player player;

    public AIController aicontroller;

    public Ball ball;

    public TMP_Text redScore;
    public TMP_Text blueScore;
    public TMP_Text timer;

    public ScoreController controller;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(controller.timer);
    }
}

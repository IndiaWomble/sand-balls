using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActiveState : BallBaseState
{
    private Color[] activeColors = { Color.red, Color.blue, Color.green, Color.magenta, Color.yellow };

   public override void EnterState(Balls ball)
    {
        ball.GetComponent<Renderer>().material.SetColor("_Color", activeColors[Random.Range(0, activeColors.Length)]);
        ball.tag = "Active";
        ball.gameManager.activeBalls.Add(ball);
    }

    public override void OnCollisionEnter(Balls ball, Collision collision)
    {
        //Empty Function as its not needed in this state
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInactiveState : BallBaseState
{
    public override void EnterState(Balls ball)
    {
        ball.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }

    public override void OnCollisionEnter(Balls ball, Collision collision)
    {
        if (collision.collider.tag == "Active") {
            ball.TransitionToState(ball.activeState);
        }
    }
}

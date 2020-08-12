using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public GameManager gameManager;
    private BallBaseState currentState;
    public readonly BallActiveState activeState = new BallActiveState();
    public readonly BallInactiveState inactiveState = new BallInactiveState();

    public BallBaseState CurrentState 
    { 
        get => currentState; 
    }

    private void Start() 
    {
        gameManager = Object.FindObjectOfType<GameManager>();
        this.TransitionToState(this.inactiveState);
    }

    public void TransitionToState(BallBaseState state) 
    {
        this.currentState = state;
        this.currentState.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        this.currentState.OnCollisionEnter(this, collision);
    }
}

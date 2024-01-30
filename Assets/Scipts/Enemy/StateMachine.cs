using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    

    private void Update()
    {
        if(activeState != null)
        {
            activeState.Performed();
        }
    }
    public void ChangeState(BaseState newState)
    {
        if(activeState != null)
        {
            activeState.Exit();
        }
        activeState = newState;

        if(activeState != null )
        {
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
    public void Initialize()
    {
        
        ChangeState(new PatrolState());
    }
}

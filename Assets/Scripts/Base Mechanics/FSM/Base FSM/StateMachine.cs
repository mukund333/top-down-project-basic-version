using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    BaseState currentState;

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    void Update()
    {

        Debug.Log(currentState);

        if (currentState != null)
        {
            currentState.UpdateLogic();
        }
    }

    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysics();
        }
    }


    // new state

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();


    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

   
    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(no current state)";

        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");

    }

}

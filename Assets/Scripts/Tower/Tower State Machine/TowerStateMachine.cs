using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStateMachine 
{
    public TowerState currentTowerState { get; set; }

    public void Initialize(TowerState startingState)
    {
        currentTowerState = startingState;
        currentTowerState.EnterState();
    }

    public void ChangeState(TowerState newState)
    {
        currentTowerState.ExitState();
        currentTowerState = newState;
        currentTowerState.EnterState();
    }
}

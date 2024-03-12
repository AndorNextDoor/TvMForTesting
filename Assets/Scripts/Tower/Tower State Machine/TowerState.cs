using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerState
{
    protected Tower tower;
    protected TowerStateMachine towerStateMachine;


    public TowerState(Tower tower, TowerStateMachine towerStateMachine)
    {
        this.tower = tower;
        this.towerStateMachine = towerStateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void AnimationTriggerEvent(Tower.AnimationTowerTriggerType triggerType) { }
    public virtual void OnCollisionEnter(Collision other) { }
}

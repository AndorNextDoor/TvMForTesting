using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIdleState : TowerState
{
    public TowerIdleState(Tower tower, TowerStateMachine towerStateMachine) : base(tower, towerStateMachine)
    {

    }

    public override void AnimationTriggerEvent(Tower.AnimationTowerTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);

        tower.towerIdleBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        tower.towerIdleBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        tower.towerIdleBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        tower.towerIdleBaseInstance.DoFrameUpdateLogic();
    }   
}

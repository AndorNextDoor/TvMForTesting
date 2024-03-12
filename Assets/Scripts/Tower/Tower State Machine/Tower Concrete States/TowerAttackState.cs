using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackState : TowerState
{
    public TowerAttackState(Tower tower, TowerStateMachine towerStateMachine) : base(tower, towerStateMachine)
    {

    }

    public override void AnimationTriggerEvent(Tower.AnimationTowerTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);

        tower.towerAttackBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        tower.towerAttackBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        tower.towerAttackBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        tower.towerAttackBaseInstance.DoFrameUpdateLogic();
    }
}

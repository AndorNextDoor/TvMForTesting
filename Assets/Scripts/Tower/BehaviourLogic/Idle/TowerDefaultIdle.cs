using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default-Idle", menuName = "Tower logic/Idle Logic/Default Idle")]
public class TowerDefaultIdle : TowerIdleSOBase
{
    public override void DoAnimationTriggerEventLogic(Tower.AnimationTowerTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
    }

    public override void Initialize(GameObject _gameObject, Tower _tower)
    {
        base.Initialize(_gameObject, _tower);

    }
}

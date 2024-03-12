using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedUp-Idle", menuName = "Tower logic/Idle Logic/SpeedUp-Idle")]
public class SpeedUpTower : TowerIdleSOBase
{

    public float timeSpeedMultiplier = 1f;

    public override void DoAnimationTriggerEventLogic(Tower.AnimationTowerTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        WaveSpawner.instance.timeSpeed = 1/timeSpeedMultiplier;
        UiManager.instance.timeSpeed = timeSpeedMultiplier;
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

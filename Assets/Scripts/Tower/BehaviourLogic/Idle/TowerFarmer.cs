using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Farmer-Idle", menuName = "Tower logic/Idle Logic/Farmer-Idle")]
public class TowerFarmer : TowerIdleSOBase
{
    public int currencyAmount;

    public float timeToGetCurrency;
    private float _timer;


    public override void DoAnimationTriggerEventLogic(Tower.AnimationTowerTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);

        if(triggerType == Tower.AnimationTowerTriggerType.Farm)
        {
            GetCurrency();
        }
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

        _timer -= Time.deltaTime;
        if(_timer <= 0 ) 
        {
            tower.animator.SetTrigger("Farm");
            _timer = timeToGetCurrency;
        }
    }


    public override void Initialize(GameObject _gameObject, Tower _tower)
    {
        base.Initialize(_gameObject, _tower);
        _timer = timeToGetCurrency;

    }
    private void GetCurrency()
    {
        GameManager.Instance.GetCurrency(currencyAmount);
    }
}

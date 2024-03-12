using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack-Basic-Projectile", menuName = "Tower logic/Attack Logic/Basic Projectile")]
public class TowerAttackBasicProjectile : TowerAttackSOBase
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float _timeBetweenHits = 2f;
    private float _timer;
   
    public override void DoAnimationTriggerEventLogic(Tower.AnimationTowerTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);

        switch (triggerType)
        {
            case Tower.AnimationTowerTriggerType.Attack:
                Shoot();
                break;


            case Tower.AnimationTowerTriggerType.AttackSound:
                AudioManager.Instance.PlaySound(tower.attackSound);
                break;
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

        if (_timer > _timeBetweenHits)
        {
            _timer = 0;
            tower.animator.SetTrigger("Attack");
        }
        _timer += Time.deltaTime;

        if(tower.currentEnemy ==  null)
        {
            tower.attackTrigger = false;
            tower.StateMachine.ChangeState(tower.idleState);
        }
    }

    void Shoot()
    {

        Instantiate(projectile, tower.firepoint.position, tower.firepoint.rotation);
    }

    public override void Initialize(GameObject _gameObject, Tower _tower)
    {
        base.Initialize(_gameObject, _tower);

        _timer = _timeBetweenHits;

    }
}

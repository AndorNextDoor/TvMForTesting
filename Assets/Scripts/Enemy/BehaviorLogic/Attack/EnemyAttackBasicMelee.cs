using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack-Basic-Melee", menuName = "Enemy Logic/Attack Logic/Melee")]
public class EnemyAttackBasicMelee : EnemyAttackSOBase
{
    [SerializeField] private float _timeBetweenHits = 2f;
    private float _timer;



    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);

        switch (triggerType)
        {
            case Enemy.AnimationTriggerType.Attacked:
                enemy.currentTowerToAttack.Damage(enemy.damage);
                break;


            case Enemy.AnimationTriggerType.AttackSound:
                AudioManager.Instance.PlaySound(enemy.attackSound);
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
            enemy.animator.SetTrigger("Attack");
        }
        _timer += Time.deltaTime;
        if(enemy.currentTowerToAttack == null)
        {
            enemy.isInAttackRange = false;
            enemy.StateMachine.ChangeState(enemy.MoveState);
        }
    }

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Move straight", menuName = "Enemy Logic/Move Logic/Straight")]
public class EnemyMoveStraight : EnemyMoveSOBase
{

    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        enemy.animator.SetBool("IsMoving", true);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        enemy.animator.SetBool("IsMoving", false);
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        MoveEnemy();
    }

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }


    public void MoveEnemy()
    {
        transform.position += transform.forward * enemy.speed * Time.deltaTime;
    }
}

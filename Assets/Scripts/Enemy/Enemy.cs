using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [field: SerializeField] public float maxHealth { get; set; }

    [field: SerializeField] public float currentHealth { get; set; }
    [field: SerializeField] public float speed { get; set; }
    [field: SerializeField] public float damage { get; set; }
    public Animator animator;
    public Tower currentTowerToAttack;
    public bool isInAttackRange;

    #region ScriptableObject Variables

    [SerializeField] private EnemyMoveSOBase enemyMoveBase;
    [SerializeField] private EnemyAttackSOBase enemyAttackBase;

    public EnemyMoveSOBase enemyMoveBaseInstance { get; set; }
    public EnemyAttackSOBase enemyAttackBaseInstance { get; set; }

    #endregion

    #region State Machine Variables

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyMovingState MoveState { get; set; }
    public EnemyAttackState AttackState { get; set; }

    #endregion

    #region
    [Header("Sounds")]
    public AudioManager.AudioSounds attackSound;
    #endregion

    private void Awake()
    {
        enemyMoveBaseInstance = Instantiate(enemyMoveBase);
        enemyAttackBaseInstance = Instantiate(enemyAttackBase);

        StateMachine = new EnemyStateMachine();

        MoveState = new EnemyMovingState(this,StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);

    }

    private void Start()
    {
        currentHealth = maxHealth;

        enemyMoveBaseInstance.Initialize(gameObject, this);
        enemyAttackBaseInstance.Initialize(gameObject, this);

        StateMachine.Initialize(MoveState);
    }

    private void Update()
    {
        if (isInAttackRange)
        {
            StateMachine.ChangeState(AttackState);
        }
            StateMachine.currentEnemyState.FrameUpdate();

    }

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.currentEnemyState.AnimationTriggerEvent(triggerType);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("LaneEnding"))
        {
            GameManager.Instance.TakeDamage(1);
            Destroy(gameObject);
        }
        if (StateMachine.currentEnemyState == null)
            return;
        StateMachine.currentEnemyState.OnCollisionEnter(collision);
    }

    #region Damage Take

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GameManager.Instance.OnEnemyDestroyed();
        Destroy(transform.parent.gameObject);
    }

    #endregion


    public enum AnimationTriggerType
    {
        Attacked,
        AttackSound
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

public class Tower : MonoBehaviour, IDamagable
{
    [Header("Tower Settings")]
    public int towerCost;
    [field: SerializeField] public float maxHealth { get; set; }
    
    [Header("Tower Scriptable Settings")]
    [SerializeField] private TowerAttackSOBase towerAttackBase;
    [SerializeField] private TowerIdleSOBase towerIdleBase;

    [Header("Assign Theese")]
    public Transform firepoint;
    public Animator animator;

  
    [HideInInspector] public Enemy currentEnemy;
    [HideInInspector] public bool attackTrigger;
    public float currentHealth { get; set; }
    #region ScriptableObject Variables


    public TowerAttackSOBase towerAttackBaseInstance { get; set; }

    public TowerIdleSOBase towerIdleBaseInstance { get; set; }

    #endregion

    #region State Machine Variables

    public TowerStateMachine StateMachine { get; set; }
    public TowerAttackState attackState { get; set; }
    public TowerIdleState idleState { get; set; }


    #endregion

    #region
    [Header("Sounds")]
    public AudioManager.AudioSounds attackSound;

    #endregion

    private void Awake()
    {
        towerAttackBaseInstance = Instantiate(towerAttackBase);
        towerIdleBaseInstance = Instantiate(towerIdleBase);

        StateMachine = new TowerStateMachine();

        idleState = new TowerIdleState(this, StateMachine);
        attackState = new TowerAttackState(this, StateMachine);

    }

    private void Start()
    {
        currentHealth = maxHealth;

        towerIdleBaseInstance.Initialize(gameObject, this);
        towerAttackBaseInstance.Initialize(gameObject, this);

        StateMachine.Initialize(idleState);
    }

    private void Update()
    {
        if (attackTrigger && StateMachine.currentTowerState != attackState) StateMachine.ChangeState(attackState);
        

        StateMachine.currentTowerState.FrameUpdate();
    }

    private void AnimationTriggerEvent(AnimationTowerTriggerType triggerType)
    {
        StateMachine.currentTowerState.AnimationTriggerEvent(triggerType);
    }


    #region Take Damage
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
        transform.parent.parent.GetComponent<Tile>().isOccupied = false;
        Destroy(transform.parent.gameObject);
    }
    #endregion
    public enum AnimationTowerTriggerType
    {
        Attack,
        Farm,
        AttackSound
    }

}

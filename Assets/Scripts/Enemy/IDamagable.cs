using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void Damage(float amount);

    void Die();

    float maxHealth {  get; set; }

    float currentHealth { get; set; }
}

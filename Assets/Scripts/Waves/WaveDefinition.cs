using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Wave Definition")]
public class WaveDefinition : ScriptableObject
{
   
    [System.Serializable]
    public class EnemyInfo
    {
        public GameObject enemyPrefab;
        public float spawnDelay = 0.3f;
    }

    public EnemyInfo[] enemies;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("MakeEnemy", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeEnemy()
    {
        // enemyPrefab を 横ランダム、縦5、奥行き 0 の位置に EnemyMaker と同じ向き？(たぶんあまり意味はない)に配置
        Instantiate (enemyPrefab, new Vector3 (-2f + 4 * Random.value, 5, 0), Quaternion.identity);
    }
}

using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float duration = 4f;
    [SerializeField] private GameObject enemyPrefab;

    private void Awake()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (duration > 0.5f) duration -= 0.5f;
            SpawnEnemy();
            yield return new WaitForSeconds(duration);
        }
        
    }

    private void SpawnEnemy()
    {
        float x = Random.Range(-5, 5);
        float y = Random.Range(-5, 5);
        Vector3 pos = new Vector3(x, y, 0);
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }


}

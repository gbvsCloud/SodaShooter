using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] private Camera mainCamera;

    [SerializeField] private List<Vector2> horizontalPositions;

    [SerializeField] private Enemy enemy;

    [SerializeField] List<Wave> waves = new();
    Vector2 cameraSize;
    public void Start()
    {

        cameraSize = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        horizontalPositions = new List<Vector2>()
        {
            new Vector2(-2.5f, cameraSize.y + 2),
            new Vector2(-1f, cameraSize.y + 2),
            new Vector2(1f, cameraSize.y + 2),
            new Vector2(2.5f, cameraSize.y + 2)
        };






        StartCoroutine(SpawnEnemy());
        
        
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            Wave randomWave = waves[Random.Range(0, waves.Count)];

            foreach(Vector2 enemyPos in randomWave.enemyPositions)
            {
                Enemy newEnemy = Instantiate(enemy, new Vector2(cameraSize.x + enemyPos.x, enemyPos.y), enemy.transform.rotation);
            }

            
            yield return new WaitForSeconds(randomWave.enemyPositions.Count * 2.5f);
        }
    }

    [System.Serializable]
    class Wave
    {
        public List<Vector2> enemyPositions = new();
        public Wave(List<Vector2> positions)
        {
            enemyPositions = positions;
        } 

    }

}

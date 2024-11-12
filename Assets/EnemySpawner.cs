using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] private Camera mainCamera;

    [SerializeField] private List<Vector2> horizontalPositions;

    [SerializeField] private Enemy enemy;
    public void Start()
    {

        Vector2 cameraSize = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        horizontalPositions = new List<Vector2>()
        {
            new Vector2(-2.5f, cameraSize.y + 2),
            new Vector2(-1f, cameraSize.y + 2),
            new Vector2(2.5f, cameraSize.y + 2),
            new Vector2(-1f, cameraSize.y + 2)
        };

        StartCoroutine(SpawnEnemy());
        
        
    }


    

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            Enemy newEnemy = Instantiate(enemy, horizontalPositions[Random.Range(0, horizontalPositions.Count)], Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
}

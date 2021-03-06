using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;

    [SerializeField]
    private GameObject[] powerups;
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(EnemySpawnRoutine());
      StartCoroutine(PowerupSpawnRoutine());   
    }

    IEnumerator EnemySpawnRoutine()
    {
        while(true)
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7f,7f),7,0),Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator PowerupSpawnRoutine()
    {
        while(true)
        {
            int  randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], new Vector3(Random.Range(-7,7),7,0),Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}

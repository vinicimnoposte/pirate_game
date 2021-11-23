using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject meleeEnemy, tankEnemy, rangedEnemy;
    public int xPos;
    public int zPos;
    public int meleeEnemyCount, rangedEnemyCount, tankEnemyCount, soma ;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
        soma = meleeEnemyCount + rangedEnemyCount + tankEnemyCount;
    }
     void Update()
    {
        Debug.Log(tankEnemyCount + "tanks!");
        Debug.Log(meleeEnemyCount + "melees!");
        Debug.Log(rangedEnemyCount + "rangeds!");
        if (soma <= 0)
        {
           // while (meleeEnemyCount < 1)
           // {
           //     xPos = Random.Range(-28, -141);
           //     zPos = Random.Range(-35, 8);
           //     Instantiate(meleeEnemy, new Vector3(xPos, 43, zPos), Quaternion.identity);
           //  //   yield return new WaitForSeconds(0.1f);
           //     meleeEnemyCount += 1;
           // } while (rangedEnemyCount < 1)
           // {
           //     xPos = Random.Range(-28, -141);
           //     zPos = Random.Range(-35, 8);
           //     Instantiate(rangedEnemy, new Vector3(xPos, 43, zPos), Quaternion.identity);
           //   //  yield return new WaitForSeconds(0.1f);
           //     rangedEnemyCount += 1;
           // } while (tankEnemyCount < 1)
           // {
           //     xPos = Random.Range(-28, -141);
           //     zPos = Random.Range(-35, 8);
           //     Instantiate(tankEnemy, new Vector3(xPos, 43, zPos), Quaternion.identity);
           //    // yield return new WaitForSeconds(0.1f);
           //     tankEnemyCount += 1;
           // }

        }
    }
    IEnumerator EnemyDrop()
    {
        while (meleeEnemyCount < 5)
        {
            xPos = Random.Range(-28, -141);
            zPos = Random.Range(-35, 8);
            Instantiate(meleeEnemy, new Vector3(xPos, 43, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            meleeEnemyCount += 1;
        } while (rangedEnemyCount < 3)
        {
            xPos = Random.Range(-28, -141);
            zPos = Random.Range(-35, 8);
            Instantiate(rangedEnemy, new Vector3(xPos, 43, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            rangedEnemyCount += 1;
        } while (tankEnemyCount < 2)
        {
            xPos = Random.Range(-28, -141);
            zPos = Random.Range(-35, 8);
            Instantiate(tankEnemy, new Vector3(xPos, 43, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            tankEnemyCount += 1;
        }      
    }
}

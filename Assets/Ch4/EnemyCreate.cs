using System;
using System.Collections;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Vector2 limitMin;
    public Vector2 limitMax;

    void Start()
    {
        StartCoroutine(CreateEnemy());    
    }

    private IEnumerator CreateEnemy()
    {
        while(true)
        {
            float range = UnityEngine.Random.Range(limitMin.x, limitMax.x);
            Vector2 creatingPoint = new Vector2(range, limitMin.y);

            Instantiate(prefabEnemy, creatingPoint, Quaternion.identity);

            float creatingTime = UnityEngine.Random.Range(0.5f, 3.0f);
            yield return new WaitForSeconds(creatingTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(limitMin, limitMax);
    }
}

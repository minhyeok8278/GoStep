using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private float spawnTimeMin = 5f;
    private float spawnTimeMax = 10f;
    private float spawnTime;

    private float yPosMin = 1f;
    private float yPosMax = 3f;
    private float yPos;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (!GameManager.Instance.IsGameOver)
        {
            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            yPos = Random.Range(yPosMin, yPosMax);

            GameObject Item = PoolManager.instance.Pop("Item");
            Item.transform.position = new Vector3(10, yPos, 0);
            ScrollingObject.instance.obj.Add(Item);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}

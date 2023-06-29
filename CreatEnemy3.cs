using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy3 : MonoBehaviour
{
    public List<GameObject> resources = new List<GameObject>();
    private List<GameObject> monster = new List<GameObject>();
    public float spawnDelay = 1f;
    public float spawnTimer = 0f;
    private int resourcesCount;
    public int monsterCount;
    // Start is called before the first frame update
    void Start()
    {
        resourcesCount = resources.Count;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0f)
        {
            Vector3 spawnPos = this.transform.position + new Vector3(Random.Range(0, 3), Random.Range(0, 3), 0);
            int aRandomRes = Random.Range(0, resourcesCount);
            monster.Add(resources[aRandomRes]);
            GameObject spawnRes = resources[aRandomRes];
            Instantiate(spawnRes, spawnPos, Quaternion.identity);
            spawnTimer = spawnDelay;

        }
    }
                   
}

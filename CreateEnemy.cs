using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class CreateEnemy : MonoBehaviour
{
    public List<GameObject> resources = new List<GameObject>();
    public float spawnDelay = 1f;
    public float spawnTimer = 0f;
    private bool[] Emptytest;
    private List<Vector3> monsterTileWorldPos = new List<Vector3>();
    private int monsterTileCount;
    private int resourcesCount;
    private Tilemap tilemap;

    public float lastTime;
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        Vector3Int tm0rg = tilemap.origin+new Vector3Int(3,3,0);
        Vector3Int tmsz = tilemap.size-new Vector3Int(6,6,0);

        for (int x = tm0rg.x; x < tmsz.x; x++)
        {
            for (int y = tm0rg.y; y < tmsz.y; y++)
            {
                if (tilemap.GetTile(new Vector3Int(x, y, 0)) != null)
                {
                    Vector3 celltowordpos = tilemap.GetCellCenterWorld(new Vector3Int(x, y, 0));
                    monsterTileWorldPos.Add(celltowordpos);
                }
            }
        }
        monsterTileCount = monsterTileWorldPos.Count;
        resourcesCount = resources.Count;
        Emptytest = new bool[monsterTileCount];
        for (int i = 0; i < monsterTileCount; i++)
        {
            Emptytest[i] = true;
        }
    }
    void Update()
    {
        lastTime -= Time.deltaTime;
        //spawnTimer -= Time.deltaTime;
        //if (spawnTimer < 0f)
        //{
        //    int aRandomTile = Random.Range(0, monsterTileCount);
        //    if (Emptytest[aRandomTile])
        //    {
        //        Vector3 spawnPos = monsterTileWorldPos[aRandomTile];
        //        int aRandomRes = Random.Range(0, resourcesCount);
        //        GameObject spawnRes = resources[aRandomRes];
        //        Instantiate(spawnRes, spawnPos, Quaternion.identity);
        //        spawnTimer = spawnDelay;
        //        Emptytest[aRandomTile] = false;
        //    }
        //}
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
            if (collision.CompareTag("Player"))
            {
                spawnTimer -= Time.deltaTime;
                if (spawnTimer < 0f)
                {
                    int aRandomTile = Random.Range(0, monsterTileCount);
                    if (Emptytest[aRandomTile])
                    {
                        Vector3 spawnPos = monsterTileWorldPos[aRandomTile];
                        int aRandomRes = Random.Range(0, resourcesCount);
                        GameObject spawnRes = resources[aRandomRes];
                        Instantiate(spawnRes, spawnPos, Quaternion.identity);
                        spawnTimer = spawnDelay;
                        Emptytest[aRandomTile] = false;
                    }
                }
            }
    }
}

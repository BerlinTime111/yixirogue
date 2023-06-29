using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collection : MonoBehaviour
{
    public List<GameObject> resources = new List<GameObject>();
    public int resourcescount;
    // Start is called before the first frame update
    void Start()
    {
        resourcescount = resources.Count;
    }

    // Update is called once per frame
    void Update()
    {
        int aRandomRes = Random.Range(0, resourcescount);
        GameObject spawnRes = resources[aRandomRes];
        Instantiate(spawnRes, transform.position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy2 : MonoBehaviour
{
    public GameObject Door_right;
    public GameObject Door_up;
    public GameObject Door_left;
    public GameObject Door_down;
    public int num;
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
        monsterCount = Random.Range(5,num);
        Door_left.GetComponent<BoxCollider2D>().enabled = false;
        Door_right.GetComponent<BoxCollider2D>().enabled = false;
        Door_down.GetComponent<BoxCollider2D>().enabled = false;
        Door_up.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (monsterCount >0)
        {
            if (collision.CompareTag("Player"))
            {
                Door_left.GetComponent<BoxCollider2D>().enabled = true;
                Door_right.GetComponent<BoxCollider2D>().enabled = true;
                Door_down.GetComponent<BoxCollider2D>().enabled = true;
                Door_up.GetComponent<BoxCollider2D>().enabled = true;
                spawnTimer -= Time.deltaTime;
                if (spawnTimer < 0f)
                {
                    Vector3 spawnPos = this.transform.position + new Vector3(Random.Range(0, 5), Random.Range(0, 5), 0);
                    int aRandomRes = Random.Range(0, resourcesCount);
                    monster.Add(resources[aRandomRes]);
                    GameObject spawnRes = resources[aRandomRes];
                    Instantiate(spawnRes, spawnPos, Quaternion.identity);
                    spawnTimer = spawnDelay;
                    monsterCount--;
                }
            }
        }
        else
        {
            if (collision.CompareTag("Player"))
            {
                if (IsEmpty())
                {
                    Door_left.GetComponent<BoxCollider2D>().enabled = false;
                    Door_right.GetComponent<BoxCollider2D>().enabled = false;
                    Door_down.GetComponent<BoxCollider2D>().enabled = false;
                    Door_up.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
            
        }

    }
    public bool IsEmpty()
    {
        if(GameObject.FindWithTag("book")==null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

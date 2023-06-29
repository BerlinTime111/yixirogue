using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    protected Transform muzzlePos;
    protected Vector3 direction;
    public GameObject player;
    protected Vector3 enemyPos;
    public float fireDelay = 1f;
    public float fireTimer = 0f;
    void Awake()
    {
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        enemyPos = transform.position;
        muzzlePos = transform.Find("Muzzle");
        direction = (player.transform.position - enemyPos).normalized;
        fireTimer -= Time.deltaTime;
        if (fireTimer < 0f)
        {
            fire();
            fireTimer = fireDelay;
        }
    }
    private void fire()
    {
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet.transform.position = muzzlePos.position;
        float angel = Random.Range(-5f, 5f);
        bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angel, Vector3.forward) * direction);
    }
}

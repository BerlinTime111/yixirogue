using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject buulletPrefab;
    public GameObject buuulletPrefab;
    public GameObject boss2;
    protected Transform muzzlePos;
    protected Vector3 direction;
    public GameObject player;
    protected Vector3 enemyPos;
    public float fireDelay = 1f;
    public float fireTimer = 0f;
    public int bulletNum = 3;
    public float bulletAngle = 15;
    private int i = 1;
    private bool j = true;
    void Awake()
    {

    }
    // Start is called before the first frame update
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
            switch (i)
            {
                case 0:
                    fire();
                    fireTimer = fireDelay;
                    i = Random.Range(0, 3);
                    break;
                case 1:
                    firee();
                    fireTimer = fireDelay;
                    i = Random.Range(0, 3);
                    break;
                case 2:
                    fireee();
                    fireTimer = fireDelay;
                    i = Random.Range(0, 3);
                    break;
            }
        }

    }
    private void fire()
    {
        int median = bulletNum / 2;
        for (int i = 0; i < bulletNum; i++)
        {
            GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
            bullet.transform.position = muzzlePos.position;

            if (bulletNum % 2 == 1)
            {
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(bulletAngle * (i - median), Vector3.forward) * direction);
            }
            else
            {
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(bulletAngle * (i - median) + bulletAngle / 2, Vector3.forward) * direction);
            }
        }
    }
    private void firee()
    {
        int median = bulletNum / 2;
        for (int i = 0; i < bulletNum; i++)
        {
            GameObject buullet = ObjectPool.Instance.GetObject(buulletPrefab);
            buullet.transform.position = muzzlePos.position;

            if (bulletNum % 2 == 1)
            {
                buullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(bulletAngle * (i - median), Vector3.forward) * direction);
            }
            else
            {
                buullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(bulletAngle * (i - median) + bulletAngle / 2, Vector3.forward) * direction);
            }
        }
    }
    private void fireee()
    {
        int median = bulletNum / 2;
        for (int i = 0; i < bulletNum; i++)
        {
            GameObject buuullet = ObjectPool.Instance.GetObject(buuulletPrefab);
            buuullet.transform.position = muzzlePos.position;

            if (bulletNum % 2 == 1)
            {
                buuullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(bulletAngle * (i - median), Vector3.forward) * direction);
            }
            else
            {
                buuullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(bulletAngle * (i - median) + bulletAngle / 2, Vector3.forward) * direction);
            }
        }
    }
    public void Dead()
    {
        Destroy(gameObject, 2f);
        if(GameObject.Find("Healbar")!=null)
        {
            GameObject.Find("Healbar").SetActive(false);
        }
        if (j)
        {
            Instantiate(boss2, transform.position, Quaternion.identity);
            GetComponent<Animator>().SetTrigger("isDead");
            //boss2.SetActive(true);
            j = false;
        }
        
       
       
    }
}

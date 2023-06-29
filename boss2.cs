using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2 : MonoBehaviour
{
    public float speed;
    public float startTime;
    public float waitTime;
    public GameObject player;
    public GameObject healbar;
    public int attack;
    public GameObject bulletPrefab;
    public GameObject buulletPrefab;
    public GameObject buuulletPrefab;
    protected Transform muzzlePos;
    protected Vector3 direction;
    protected Vector3 enemyPos;
    public float fireDelay = 1f;
    public float fireTimer = 0f;
    public int bulletNum = 3;
    public float bulletAngle = 15;
    public float testtime = 1;
    public float scope = 2;
    private int i = 1;
    Vector3 v;
    // Start is called before the first frame update
    void Start()
    {
       
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyPos = transform.position;
        muzzlePos = transform.Find("Muzzle");
        direction = (player.transform.position - enemyPos).normalized;
        fireTimer -= Time.deltaTime;
        testtime -= Time.deltaTime;
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
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            this.transform.position = player.transform.position;
            waitTime = startTime;
            testtime = 0.5f;
        }
        else
        {
            GetDirection();
            this.GetComponent<Rigidbody2D>().MovePosition(this.transform.position + v * speed * Time.deltaTime);
        }
        if (testtime <= 0)
        {
            if ((player.transform.position - this.transform.position).magnitude <= scope)
            {
                player.GetComponent<Attribute>()?.TakeDamage(this);
                testtime = 100;
            }
        }
    }
    public void GetDirection()
    {
        v = new Vector3(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y, 0).normalized;
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
        Destroy(gameObject,0.1f);
        healbar.SetActive(false);
    }
}

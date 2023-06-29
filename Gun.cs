using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float interval;
    public GameObject bulletPrefab;
    protected Transform muzzlePos;
    protected Vector2 mousePos;
    protected Vector2 direction;
    protected float timer;
    protected float flipY;
    protected Animator animator;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        muzzlePos = transform.Find("Muzzle");
        flipY = transform.localScale.y;
    }

    protected virtual void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if (mousePos.x < transform.position.x)
        //    transform.localScale = new Vector3(flipY, -flipY, 1);
        //else
        //    transform.localScale = new Vector3(flipY, flipY, 1);

        Shoot();
    }

    protected virtual void Shoot()
    {
        direction = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        transform.right = direction;

        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                timer = 0;
        }

        if (Input.GetButton("Fire1"))
        {
            if (timer == 0)
            {
                timer = interval;
                Fire();
            }
        }
    }

    protected virtual void Fire()
    {
        animator.SetTrigger("Shoot");

        // GameObject bullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity);
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet.transform.position = muzzlePos.position;

        float angel = Random.Range(-5f, 5f);
        bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angel, Vector3.forward) * direction);
    }
}

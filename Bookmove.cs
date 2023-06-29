using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookmove : MonoBehaviour
{
    public float speed;
    public float scope;
    public float startTime;
    public float waitTime;
    public GameObject player;
    Vector3 v;
    Vector3 v3;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startTime;
        GetRandowDirection();
        player = GameObject.Find("Player");
        speed = Random.Range(2f,3f);
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((player.transform.position - this.transform.position).magnitude <= scope && (player.transform.position - this.transform.position).magnitude>=0.5f)
        {
            GetDirection();
            this.GetComponent<Rigidbody2D>().MovePosition(this.transform.position + v * speed * Time.fixedDeltaTime);
        }
        else
        {
            if(waitTime>0)
            {
                this.transform.position = (this.transform.position + v3 * speed * Time.deltaTime);
                waitTime -= Time.deltaTime;
            }
            else
            {
                waitTime = startTime;
                GetRandowDirection();
            }
            
        }

    }
    public void GetDirection()
    {
        if ((player.transform.position - this.transform.position).magnitude <= scope)
        {
            v = new Vector3(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y, 0).normalized;
        }

    }
    public void GetRandowDirection()
    {
        float v1 = Random.Range(-1f, 1f);
        float v2 = Random.Range(-1f, 1f);
        v3 = new Vector3(v1, v2, 0).normalized;
    }

}

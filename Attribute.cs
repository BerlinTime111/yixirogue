using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Attribute : MonoBehaviour
{
    [Header("基本属性")]
    public float maxBlood;
    public float currentBlood;
    public float def;
    public float exp;
    public int level;
    [Header("受伤无敌")]
    public float invulnerableDuration;
    public float invulnerableCounter;
    public bool invulnerable;
    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent OnDead;
    [Header("受伤显示")]
    public GameObject floatPoint;

    public int[] level_exp;
    // Start is called before the first frame update
    void Awake()
    {
        level = 1;
        currentBlood = maxBlood;
        level_exp = new int[10] {100, 200, 300, 400, 500, 600, 700, 800, 900, 1000};
    }

    // Update is called once per frame
    void Update()
    {
        if(invulnerable)
        {
            
            invulnerableCounter -= Time.deltaTime;
            if(invulnerableCounter<=0)
            {
                invulnerable = false;
            }
        }
        if(currentBlood<=0)
        {
            
        }
        levelup();
    }
    public void TakeDamage(Attack attacker)
    {
        if (invulnerable)
        {
            return;
        }
        if(currentBlood-attacker.damage>0)
        {
            if(def>attacker.damage)
            {
                GameObject gb=Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
                gb.transform.GetChild(0).GetComponent<TextMesh>().text = "1";
                currentBlood = currentBlood -1;
            }
            else
            {
                GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
                gb.transform.GetChild(0).GetComponent<TextMesh>().text = (attacker.damage -def).ToString();
                currentBlood = currentBlood - attacker.damage + def;
            }
            TriggerInvulnerable();
            //执行受伤
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            currentBlood = 0;
            attacker.GetComponent<Attribute>().exp +=Random.Range(1,5);
            OnDead?.Invoke();
        }
       
       

    }
    public void TakeDamage(Bullet attacker)
    {
        if (invulnerable)
        {
            return;
        }
        if (currentBlood - attacker.attack > 0)
        {
            if (def > attacker.attack)
            {
                GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
                gb.transform.GetChild(0).GetComponent<TextMesh>().text = "1";
                currentBlood = currentBlood - 1;
            }
            else
            {
                GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
                gb.transform.GetChild(0).GetComponent<TextMesh>().text = (attacker.attack-def).ToString();
                currentBlood = currentBlood - attacker.attack + def;
            }
            TriggerInvulnerable();
            //执行受伤
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            currentBlood = 0;
            OnDead?.Invoke();
        }



    }
    public void TakeDamage(boss2 attacker)
    {
        if (invulnerable)
        {
            return;
        }
        if (currentBlood - attacker.attack > 0)
        {
            if (def >=attacker.attack)
            {
                GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
                gb.transform.GetChild(0).GetComponent<TextMesh>().text = "1";
                currentBlood = currentBlood - 1;
            }
            else
            {
                GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
                gb.transform.GetChild(0).GetComponent<TextMesh>().text = (attacker.attack - def).ToString();
                currentBlood = currentBlood - attacker.attack + def;
            }
            TriggerInvulnerable();
            //执行受伤
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            currentBlood = 0;
            OnDead?.Invoke();
        }



    }
    public void TakeDamage(PlayerAttack attacker)
    {
        if (invulnerable)
        {
            return;
        }
        if (currentBlood - attacker.damage > 0)
        {
            if (def > attacker.damage)
            {
                GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
                gb.transform.GetChild(0).GetComponent<TextMesh>().text = "1";
                currentBlood = currentBlood - 1;
            }
            else
            {
                GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
                gb.transform.GetChild(0).GetComponent<TextMesh>().text = (attacker.damage-def).ToString();
                currentBlood = currentBlood - attacker.damage + def;
            }
            TriggerInvulnerable();
            //执行受伤
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            currentBlood = 0;
            OnDead?.Invoke();
        }



    }
    public void TakeDamage(BookAttack attacker)
    {
        if (invulnerable)
        {
            return;
        }
        if (currentBlood - attacker.damage > 0)
        {
            if (def > attacker.damage)
            {
                GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
                gb.transform.GetChild(0).GetComponent<TextMesh>().text = "1";
                currentBlood = currentBlood - 1;
            }
            else
            {
                GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
                gb.transform.GetChild(0).GetComponent<TextMesh>().text = (attacker.damage - def).ToString();
                currentBlood = currentBlood - attacker.damage + def;
            }
            TriggerInvulnerable();
            //执行受伤
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            currentBlood = 0;
            OnDead?.Invoke();
        }



    }
    private void TriggerInvulnerable()
    {
        if(!invulnerable)
        {
            invulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }
    private void levelup()
    {
        switch(level)
        {
            case 1:
                if(exp>level_exp[0])
                {
                   
                    maxBlood = maxBlood + 2;
                    def++;
                    this.transform.GetChild(2).GetComponent<PlayerAttack>().damage += 2;
                    exp -=level_exp[0];
                    level++;
                }
                break;
            case 2:
                if (exp >level_exp[1])
                {
                    
                    maxBlood = maxBlood + 3;
                    def = def + 2;
                    this.transform.GetChild(2).GetComponent<PlayerAttack>().damage += 2;
                    exp = exp - level_exp[1];
                    level++;
                }
                break;
            case 3:
                if (exp > level_exp[2])
                {
                   
                    maxBlood = maxBlood + 3;
                    def = def + 2;
                    this.transform.GetChild(2).GetComponent<PlayerAttack>().damage += 2;
                    exp = exp - level_exp[2];
                    level++;
                }
                break;
            case 4:
                if (exp > level_exp[3])
                {
                    
                    maxBlood = maxBlood + 3;
                    def = def + 2;
                    this.transform.GetChild(2).GetComponent<PlayerAttack>().damage += 2;
                    exp = exp - level_exp[3];
                    level++;
                }
                break;
            case 5:
                if (exp > level_exp[4])
                {
                    
                    maxBlood = maxBlood + 3;
                    def = def + 2;
                    this.transform.GetChild(2).GetComponent<PlayerAttack>().damage += 2;
                    exp = exp - level_exp[4];
                    level++;
                }
                break;
            case 6:
                if (exp > level_exp[5])
                {
                    
                    maxBlood = maxBlood + 3;
                    def = def + 2;
                    this.transform.GetChild(2).GetComponent<PlayerAttack>().damage += 2;
                    exp = exp - level_exp[5];
                    level++;
                }
                break;
            case 7:
                if (exp > level_exp[6])
                {

                    maxBlood = maxBlood + 3;
                    def = def + 2;
                    this.transform.GetChild(2).GetComponent<PlayerAttack>().damage += 2;
                    exp = exp - level_exp[6];
                    level++;
                }
                break;
            case 8:
                if (exp > level_exp[7])
                {
                    
                    maxBlood = maxBlood + 3;
                    def = def + 2;
                    this.transform.GetChild(2).GetComponent<PlayerAttack>().damage += 2;
                    exp = exp - level_exp[7];
                    level++;
                }
                break;
            case 9:
                if (exp > level_exp[8])
                {
                    
                    maxBlood = maxBlood + 3;
                    def = def + 2;
                    this.transform.GetChild(2).GetComponent<PlayerAttack>().damage += 2;
                    exp = exp - level_exp[8];
                    level++;
                }
                break;
            case 10:
                if (exp > level_exp[9])
                {
                    
                    maxBlood = maxBlood + 3;
                    def = def + 2;
                    this.transform.GetChild(2).GetComponent<PlayerAttack>().damage += 2;
                    exp = exp - level_exp[9];
                    level++;
                }
                break;
        }
    }
    public void ExpUp()
    {
        exp += 5;
    }
}

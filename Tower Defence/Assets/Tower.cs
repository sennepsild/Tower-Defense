using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Cannon cannon;

    LayerMask mask;

    public GameObject[] bullets;


    float cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        cannon = new Cannon();

        mask = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0)
        {

            Collider[] colliders = Physics.OverlapSphere(transform.position, cannon.range, mask);

            if (colliders.Length > 0)
            {
                shoot(colliders[0].transform.position);
            }
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    void shoot(Vector3 target)
    {

        cooldown = cannon.cooldown;
        GameObject temp =  Instantiate(bullets[cannon.bulletType], transform.position+Vector3.up*.35f, Quaternion.identity);
        temp.GetComponent<Bullet>().target = target;
        temp.GetComponent<Bullet>().damage = cannon.damage;

    }


}

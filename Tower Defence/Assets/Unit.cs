using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public static LevelManager levelManager;

    public Transform[] waypoints;
    int currentWaypoint = 0;

    public float speed = 5;
    public float maxHealth = 100;
    float health;



    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        lookAtWaypoint();


    }

    // Update is called once per frame
    void Update()
    {

        walkToWayPoint();


    }

    void walkToWayPoint()
    {



        if(currentWaypoint < waypoints.Length)
        {

            transform.Translate(Vector3.forward *Time.deltaTime *speed);

            Vector3 pos = waypoints[currentWaypoint].position;
            pos.y = transform.position.y;

            if (Vector3.Distance(transform.position, pos) < 0.1f)
            {

                
                currentWaypoint += 1;

                if(currentWaypoint >= waypoints.Length)
                {
                    levelManager.removeFromActiveUnits(gameObject);
                    Destroy(gameObject);
                }
                else
                lookAtWaypoint();
            }

        }



        

    }



    
    void lookAtWaypoint()
    {
        Vector3 pos = waypoints[currentWaypoint].position;
        pos.y = transform.position.y;

        transform.LookAt(pos);

    }


    public void Hit(float damage)
    {

        health -= damage;
        if(health<= 0)
        {
            levelManager.Blood.transform.position = transform.position;
            levelManager.Blood.Emit(50);
            levelManager.removeFromActiveUnits(gameObject);
            Destroy(gameObject);
        }
    }
    


}

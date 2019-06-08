using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int CurrentLevel;

    public Transform spawnPoint;
    public Transform[] waypoints;


    public ParticleSystem Blood;

    List<GameObject> activeUnits = new List<GameObject>();

    public GameObject[] enemies;


    // Start is called before the first frame update
    void Start()
    {
        Bullet.Blood = Blood;
        Unit.levelManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(activeUnits.Count <= 0)
        {
            StartCoroutine(spawnUnits(CurrentLevel));

        }

    }

    IEnumerator spawnUnits(int level)
    {

        for (int i = 0; i < 10; i++)
        {
            GameObject unit = Instantiate(enemies[level], spawnPoint.position, Quaternion.identity);
            unit.GetComponent<Unit>().waypoints = waypoints;

            activeUnits.Add(unit);
            yield return new WaitForSeconds(0.3f);
        }
        


    }


    public void removeFromActiveUnits(GameObject obj)
    {
        activeUnits.Remove(obj);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static ParticleSystem Blood;

    public float speed;
    public float damage;

    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime*speed);
       
    }


    private void OnCollisionEnter(Collision collision)
    {
       if( collision.gameObject.layer == 8)
        {
            print("HIT!");

            Blood.transform.position = transform.position;
            Blood.Emit(50);

            collision.gameObject.GetComponent<Unit>().Hit(damage);
            Destroy(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}

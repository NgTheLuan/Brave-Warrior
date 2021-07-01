using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRobot : MonoBehaviour
{
    public float lifetime = 2; //Sau 2s mat bullet

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true)
        {
            if (col.CompareTag("player"))
            {
                col.SendMessageUpwards("Damage", 1);
            }
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}

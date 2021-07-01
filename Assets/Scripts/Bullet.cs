using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        Vector2 temp = transform.position;
        temp.x += 25 * Time.deltaTime;
        transform.position = temp;
        if (temp.x > 6) Destroy(this.gameObject);
    }

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Monster")
    //    {
    //        Destroy(gameObject);
    //    }

    //}
}
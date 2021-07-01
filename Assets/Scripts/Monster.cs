using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Monster : MonoBehaviour
{
    public int Health = 100;
    public AudioSource audiosrc;
    public AudioClip monster;


    public Player player;
    public int dame = 1;

    private float speed = 2f;
    [SerializeField]
    private GameObject effect;

    //public GameObject score;

    private void Start()
    {
        audiosrc = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;

        temp.x -= speed * Time.deltaTime;
        if (temp.x < -8)
        {
            temp.x = -8;
            speed = -speed;
        }
        if (temp.x > 8)
        {
            temp.x = 8;
            speed = -speed;
        }

        transform.position = temp;

        if (Health <= 0)
        {
            Destroy(gameObject);
            Destroy(Instantiate(effect, transform.position, this.transform.rotation), 2);
        }
    }

    void Damage(int damage)
    {
        audiosrc.PlayOneShot(monster, 0.8f);
        Health -= damage;

      

        //GameObject os = Instantiate(score, transform.position, Quaternion.identity);
        //os.transform.GetComponent<TextMeshPro>().text = "+500";
        //Destroy(os, 1f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(Instantiate(effect, transform.position, this.transform.rotation), 2);
        }

        if (collision.CompareTag("player"))
        {
            player.Damage(dame);
            player.Knockback(400f, player.transform.position);
        }
    }

}
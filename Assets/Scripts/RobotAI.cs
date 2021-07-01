using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAI : MonoBehaviour
{
    public int curHealth = 40;

    public float distance; //khoang cach Player - Robot
    public float wakerange; //khoang cach Robot hoat dong
    public float shootinterval;
    public float bulletspeed = 3;
    public float bullettimer; //gioi han dan ban

    public bool awake = false;
    public bool lookingRight = true;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootpointL, shootpointR;
    //public SoundManager sound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookRight", lookingRight);

        RangeCheck();

        //kiem tra Player dang dung phia nao
        if (target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }

        if (target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }

        if (curHealth < 0)
        {
            //sound.Playsound("destroy");
            Destroy(gameObject);
        }
    }

    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < wakerange)
            awake = true;

        if (distance > wakerange)
            awake = false;
    }

    public void Attack(bool attackright)
    {
        bullettimer += Time.deltaTime;

        if (bullettimer >= shootinterval)
        {
            //huong vien dan = vi tri Player - Robot
            Vector2 direction = target.transform.position - transform.position;
            //lam bien Vector2 binh thuong lai
            direction.Normalize();

            if (attackright)
            {
                GameObject bulletclone;
                // Khoi tao buller, tu vi tri shootpointR va xoay theo shootpointR
                bulletclone = Instantiate(bullet, shootpointR.transform.position, shootpointR.transform.rotation) as GameObject;
                //thay doi van toc thanh huong Player * bulletspeed
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

                bullettimer = 0;
            }

            if (!attackright)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootpointL.transform.position, shootpointL.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
                bullettimer = 0;
            }
        }
    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
        //gameObject.GetComponent<Animation>().Play("redflash");
    }

}

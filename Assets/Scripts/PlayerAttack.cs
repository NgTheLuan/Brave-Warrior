using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackdelay = 0.4f;
    public bool attacking = false;

    public AudioSource audioSource;
    public AudioClip AudioShoot;
    [SerializeField]
    private GameObject bullet;

    public Animator anim;

    public Collider2D trigger;
    public SoundManager sound;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !attacking) //Attack
        {
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.3f;
            sound.Playsound("punch");
        }

        if (Input.GetKeyUp(KeyCode.X)) //Shoot
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            sound.Playsound("gun");
        }


        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }

        anim.SetBool("Attacking", attacking);
    }
}

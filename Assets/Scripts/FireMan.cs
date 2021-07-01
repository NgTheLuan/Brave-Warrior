using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMan : MonoBehaviour
{
    public int Health = 100;
    public AudioSource audiosrc;
    public AudioClip Fireman;

    private void Start()
    {
        audiosrc = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Damage(int damage)
    {
        audiosrc.PlayOneShot(Fireman, 0.8f);
        Health -= damage;
    }
}

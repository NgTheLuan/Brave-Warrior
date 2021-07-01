using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coins, gun, destroy, punch, jump;
    public AudioSource adisrc;

    // Start is called before the first frame update
    void Start()
    {
        coins = Resources.Load<AudioClip>("Game coin");
        gun = Resources.Load<AudioClip>("Gun fight");
        punch = Resources.Load<AudioClip>("Punch");
        jump = Resources.Load<AudioClip>("Jump");
        destroy = Resources.Load<AudioClip>("Rock Crash");
        adisrc = GetComponent<AudioSource>();//xác định nguồn audio
    }

    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "coins":
                adisrc.clip = coins;
                adisrc.PlayOneShot(coins, 0.6f);
                break;

            case "destroy":
                adisrc.clip = destroy;
                adisrc.PlayOneShot(destroy, 1f);
                break;

            case "gun":
                adisrc.clip = gun;
                adisrc.PlayOneShot(gun, 1f);
                break;

            case "punch":
                adisrc.clip = punch;
                adisrc.PlayOneShot(punch, 1f);
                break;

            case "jump":
                adisrc.clip = jump;
                adisrc.PlayOneShot(jump, 1f);
                break;
        }
    }
}

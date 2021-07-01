using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Player player;
    public int dame = 1;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("player"))
        {
            player.Damage(dame);
            player.Knockback(400f, player.transform.position);
        }
    }
}

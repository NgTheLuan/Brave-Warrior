using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMonster : MonoBehaviour
{
    [SerializeField]
    private GameObject Monster;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CreateMonster());
    }


    IEnumerator CreateMonster()
    {
        yield return new WaitForSeconds(6);
        Vector2 temp = transform.position;
        temp.x += Random.Range(-2, 2);
        Instantiate(Monster, temp, this.transform.rotation);
        StartCoroutine(CreateMonster());
    }
}
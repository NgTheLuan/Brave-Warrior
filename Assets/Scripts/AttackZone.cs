using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public RobotAI robot;
    public bool isLeft = false;

    private void Awake()
    {
        robot = gameObject.GetComponentInParent<RobotAI>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("player"))
        {
            if (isLeft)
                robot.Attack(false);

            if (!isLeft)
                robot.Attack(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDefinition : MonoBehaviour
{
    public Transform[] listPoint;
    private int startAt = 0;
    private int directionMove = 1;
    public void OnDrawGizmos()
    {
        if (listPoint == null || listPoint.Length < 2)
            return;
        for (int i = 1; i < listPoint.Length; i++)
        {
            Gizmos.DrawLine(listPoint[i - 1].position, listPoint[i].position);
        }
    }
    public Transform getPointAt(int p) // trả về tọa độ điểm p
    {
        return listPoint[p];
    }
    public Transform getNextPoint() //trả về điểm tiếp theo. Đổi hướng nếu đến điiểm cuối
    {
        if (startAt == 0)
            directionMove = 1;
        else if (startAt == listPoint.Length - 1)
            directionMove = -1;
        startAt += directionMove;
        return listPoint[startAt];
    }
}

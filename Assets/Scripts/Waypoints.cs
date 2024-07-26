using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Waypoints Instance { get; private set; } //����

    private List<Transform> waypointList; //�洢·���㼯��

    private void Awake()
    {
        Instance = this;
        Init(); //��ʼ��
    }

    private void Init()
    {
        Transform[] transfroms = transform.GetComponentsInChildren<Transform>();
        waypointList = new List<Transform>(transfroms);
        waypointList.RemoveAt(0);
    }

    /// <summary>
    /// ��ȡ·����ĸ���
    /// </summary>
    /// <returns></returns>
    public int GetLength()
    {
        return waypointList.Count;
    }


    /// <summary>
    /// ��ȡĳ��·�����λ��
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Vector3 GetWaypoint(int index)
    {
        return waypointList[index].position;
    }
}

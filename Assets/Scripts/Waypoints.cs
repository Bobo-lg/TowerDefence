using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Waypoints Instance { get; private set; } //单例

    private List<Transform> waypointList; //存储路径点集合

    private void Awake()
    {
        Instance = this;
        Init(); //初始化
    }

    private void Init()
    {
        Transform[] transfroms = transform.GetComponentsInChildren<Transform>();
        waypointList = new List<Transform>(transfroms);
        waypointList.RemoveAt(0);
    }

    /// <summary>
    /// 获取路径点的个数
    /// </summary>
    /// <returns></returns>
    public int GetLength()
    {
        return waypointList.Count;
    }


    /// <summary>
    /// 获取某个路径点的位置
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Vector3 GetWaypoint(int index)
    {
        return waypointList[index].position;
    }
}

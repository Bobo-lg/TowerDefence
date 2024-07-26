using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int pointIndex = 0;

    private Vector3 targetPosition = Vector3.zero;

    public float speed = 4;

    public float hp = 100;
    private float maxHP = 0;
    public GameObject explosionPrefab;

    
    private Slider hpSlider;


    //AI移动



    //导航组件
    private NavMeshAgent navMeshAgent;

    //导航点数组
    public Transform[] wayPoints;

    //当前巡逻目标点的索引
    private int currentPointIndex = 0;



    void Start()
    {
        //targetPosition = Waypoints.Instance.GetWaypoint(pointIndex);


        navMeshAgent = GetComponent<NavMeshAgent>();
        hpSlider = transform.Find("Canvas/HPSlider").GetComponent<Slider>();
        hpSlider.value = 1;
        maxHP = hp;


        //初始驱动敌人
        navMeshAgent.SetDestination(wayPoints[currentPointIndex].position);
    }


    void Update()
    {

        /*
        * 当前敌人离巡逻目标的距离小于停止距离 （即到达了）
        * 就换下一个巡逻点
        * 
        */


        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentPointIndex++;

            if (currentPointIndex > wayPoints.Count() -1)
            {
                return;
            }

            navMeshAgent.SetDestination(wayPoints[currentPointIndex].position);
        }

    }

    /// <summary>
    /// 向下一个点移动
    /// </summary>
    //private void MoveNextPoint()
    //{
    //    pointIndex++; //索引增加


    //    //如果超出索引说明已经是最后一个点
    //    if (pointIndex > (Waypoints.Instance.GetLength() - 1))
    //    {
    //        GameManager.Instance.Fail(); //失败
    //        Die();return; //死亡然后返回
    //    }

    //    //更改目标点
    //    targetPosition = Waypoints.Instance.GetWaypoint(pointIndex);
    //}



    /// <summary>
    /// 死亡
    /// </summary>
    void Die()
    {
        Destroy(gameObject); //删除自己
        EnemySpawner.Instance.DecreateEnemyCount(); //扣除敌人数量

        //爆炸特效
        GameObject go = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity); 
        Destroy(go, 1);
    }


    /// <summary>
    /// 受伤
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp / maxHP;
        if (hp <= 0)
        {
            Die();
        }
    }
}

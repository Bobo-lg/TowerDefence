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


    //AI�ƶ�



    //�������
    private NavMeshAgent navMeshAgent;

    //����������
    public Transform[] wayPoints;

    //��ǰѲ��Ŀ��������
    private int currentPointIndex = 0;



    void Start()
    {
        //targetPosition = Waypoints.Instance.GetWaypoint(pointIndex);


        navMeshAgent = GetComponent<NavMeshAgent>();
        hpSlider = transform.Find("Canvas/HPSlider").GetComponent<Slider>();
        hpSlider.value = 1;
        maxHP = hp;


        //��ʼ��������
        navMeshAgent.SetDestination(wayPoints[currentPointIndex].position);
    }


    void Update()
    {

        /*
        * ��ǰ������Ѳ��Ŀ��ľ���С��ֹͣ���� ���������ˣ�
        * �ͻ���һ��Ѳ�ߵ�
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
    /// ����һ�����ƶ�
    /// </summary>
    //private void MoveNextPoint()
    //{
    //    pointIndex++; //��������


    //    //�����������˵���Ѿ������һ����
    //    if (pointIndex > (Waypoints.Instance.GetLength() - 1))
    //    {
    //        GameManager.Instance.Fail(); //ʧ��
    //        Die();return; //����Ȼ�󷵻�
    //    }

    //    //����Ŀ���
    //    targetPosition = Waypoints.Instance.GetWaypoint(pointIndex);
    //}



    /// <summary>
    /// ����
    /// </summary>
    void Die()
    {
        Destroy(gameObject); //ɾ���Լ�
        EnemySpawner.Instance.DecreateEnemyCount(); //�۳���������

        //��ը��Ч
        GameObject go = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity); 
        Destroy(go, 1);
    }


    /// <summary>
    /// ����
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

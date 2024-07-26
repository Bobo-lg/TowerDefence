using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    
    public List<GameObject> enemyList = new List<GameObject>(); //�洢�ڷ�Χ�ڵĵ����б�


    public GameObject bulletPrefab; //�ӵ�Ԥ����
    public Transform bulletPosition; //�ӵ�����λ��
    public float attackRate = 1; //ʱ����
    private float nextAttackTime; //��ʱ�жϱ���

    private Transform head;

    protected virtual void Start()
    {
        head = transform.Find("Head");
    }


    private void Update()
    {
        DirectionControl();
        Attack();
    }


    #region �������Ƿ���빥����Χ
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyList.Remove(other.gameObject);
        }
    }
    #endregion



    /// <summary>
    /// ��������
    /// </summary>
    protected virtual void Attack()
    {
        //�е��˲Ź���
        if (enemyList == null || enemyList.Count == 0) return;
        
        //����ʱ�����͹���
        if (Time.time > nextAttackTime)
        {
            Transform target = GetTarget();
            if (target != null)
            {
                //ʵ�����ӵ�Ԥ����
                GameObject go = GameObject.Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);

                //�����ӵ���Ҫ׷�ٵ�Ŀ��
                go.GetComponent<Bullet>().SetTarget(target);
                
                //����ʱ��
                nextAttackTime = Time.time + attackRate;
            }
            
        }
    }


    /// <summary>
    /// ��ȡһ��Ŀ�꣬���������б��Ƿ�Ϊ��
    /// </summary>
    /// <returns></returns>
    public Transform GetTarget()
    {
        if(enemyList!=null && enemyList.Count > 0 && enemyList[0] != null)
        {
            return enemyList[0].transform;
        }
        if (enemyList == null || enemyList.Count == 0) return null;

        List<int> indexList = new List<int>();
        for(int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null || enemyList[i].Equals(null))
            {
                indexList.Add(i);
            }
        }
        for(int i = indexList.Count - 1; i >= 0; i--)
        {
            enemyList.RemoveAt(indexList[i]);
        }
        if(enemyList!=null && enemyList.Count != 0)
        {
            return enemyList[0].transform;
        }
        return null;

    }




    /// <summary>
    /// ������̨ת��
    /// </summary>
    private void DirectionControl()
    {
        Transform target = GetTarget();
        if (target == null) return;

        Vector3 targetPosition = target.position;
        targetPosition.y = head.position.y;

        head.LookAt(targetPosition);
    }
}

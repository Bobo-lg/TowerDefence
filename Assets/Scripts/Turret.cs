using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    
    public List<GameObject> enemyList = new List<GameObject>(); //存储在范围内的敌人列表


    public GameObject bulletPrefab; //子弹预制体
    public Transform bulletPosition; //子弹发射位置
    public float attackRate = 1; //时间间隔
    private float nextAttackTime; //计时判断变量

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


    #region 检测敌人是否进入攻击范围
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
    /// 攻击方法
    /// </summary>
    protected virtual void Attack()
    {
        //有敌人才攻击
        if (enemyList == null || enemyList.Count == 0) return;
        
        //到达时间间隔就攻击
        if (Time.time > nextAttackTime)
        {
            Transform target = GetTarget();
            if (target != null)
            {
                //实例化子弹预制体
                GameObject go = GameObject.Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);

                //设置子弹需要追踪的目标
                go.GetComponent<Bullet>().SetTarget(target);
                
                //重置时间
                nextAttackTime = Time.time + attackRate;
            }
            
        }
    }


    /// <summary>
    /// 获取一个目标，看看敌人列表是否为空
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
    /// 控制炮台转向
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

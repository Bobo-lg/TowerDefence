using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 50; //子弹伤害
    public float speed = 10; //子弹飞行速度

    public GameObject bulletExplosionPrefab;

    private Transform target;

    private void Update()
    {
        //子弹途中目标丢失就死亡
        if (target == null)
        {
            Dead();
            return;
        }


        //一直看着目标 并朝前方飞行 相当于追踪
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        //子弹打到敌人就死亡
        if (Vector3.Distance(transform.position, target.position) < 1.2)
        {
            Dead();
            target.GetComponent<Enemy>().TakeDamage(damage);
        }
    }


    //设置目标 
    public void SetTarget(Transform _target)
    {
        target = _target;
    }




    /// <summary>
    /// 死亡 销毁自身
    /// </summary>
    private void Dead()
    {
        Destroy(gameObject);
        
        //爆炸特效
        GameObject go = GameObject.Instantiate(bulletExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(go, 1);

        if (target != null)
        {
            go.transform.parent = target.transform;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 50; //�ӵ��˺�
    public float speed = 10; //�ӵ������ٶ�

    public GameObject bulletExplosionPrefab;

    private Transform target;

    private void Update()
    {
        //�ӵ�;��Ŀ�궪ʧ������
        if (target == null)
        {
            Dead();
            return;
        }


        //һֱ����Ŀ�� ����ǰ������ �൱��׷��
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        //�ӵ��򵽵��˾�����
        if (Vector3.Distance(transform.position, target.position) < 1.2)
        {
            Dead();
            target.GetComponent<Enemy>().TakeDamage(damage);
        }
    }


    //����Ŀ�� 
    public void SetTarget(Transform _target)
    {
        target = _target;
    }




    /// <summary>
    /// ���� ��������
    /// </summary>
    private void Dead()
    {
        Destroy(gameObject);
        
        //��ը��Ч
        GameObject go = GameObject.Instantiate(bulletExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(go, 1);

        if (target != null)
        {
            go.transform.parent = target.transform;
        }
    }
}

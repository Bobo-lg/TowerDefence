using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{

    private GameObject turretGO;
    private TurretData turretData;

    public GameObject buildEffect;

    private Color normalColor;
    private bool isUpgraded = false;

    private void Start()
    {
        normalColor = GetComponent<MeshRenderer>().material.color;
    }


    /// <summary>
    /// �������ֲ��̨
    /// </summary>
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() == true) return; //�㵽UI�ͷ���
        
        //��ǰ������û����̨�ͽ��� �о���ʾ����
        if (turretGO != null)
        {
            BuildManager.Instance.ShowUpgradeUI(this,transform.position, isUpgraded);
        }
        else
        {
            BuildTurret();
        }
    }

    /// <summary>
    /// ������̨
    /// </summary>
    private void BuildTurret()
    {
        //�õ�turretData ��һ�°�ȫУ��
        turretData = BuildManager.Instance.selectedTurretData;
        if (turretData == null || turretData.turretPrefab == null) return;

        //����������Ǯ ����Ǯ�Ͳ�������
        if (BuildManager.Instance.IsEnough(turretData.cost)==false)
        {
            return;
        }

        //��Ǯ�Ϳ��Կ�Ǯ��
        BuildManager.Instance.ChangeMoney(-turretData.cost);

        //����Ǯ��ʵ������̨
        turretGO = InstantiateTurret(turretData.turretPrefab);
    }


    /// <summary>
    /// ʵ������̨���巽��
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    private GameObject InstantiateTurret(GameObject prefab)
    {
        //ʵ������̨
        GameObject turretGo = GameObject.Instantiate(prefab, transform.position, Quaternion.identity);

        //����������Ч
        GameObject go = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity); 
        Destroy(go, 2);
        
        //���ػ�ȥ
        return turretGo;
    }



    /// <summary>
    /// ���������
    /// </summary>
    private void OnMouseEnter()
    {
        if (turretGO == null && EventSystem.current.IsPointerOverGameObject() == false)
        {
            GetComponent<MeshRenderer>().material.color = normalColor*0.3f;
        }
    }

    

    /// <summary>
    /// ����뿪
    /// </summary>
    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color = normalColor;
    }






    public void OnTurretUpgrade()
    {
        if (BuildManager.Instance.IsEnough(turretData.costUpgraded))
        {
            isUpgraded = true;
            BuildManager.Instance.ChangeMoney(-turretData.costUpgraded);
            Destroy(turretGO);
            turretGO = InstantiateTurret(turretData.turretUpgradedPrefab);
        }
    }

    public void OnTurretDestroy()
    {
        Destroy(turretGO);
        turretData = null;
        turretGO = null;

        
        GameObject go = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(go, 2);
    }


    
}

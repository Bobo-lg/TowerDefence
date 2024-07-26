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
    /// 鼠标点击种植炮台
    /// </summary>
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() == true) return; //点到UI就返回
        
        //当前格子上没有炮台就建造 有就提示升级
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
    /// 建造炮台
    /// </summary>
    private void BuildTurret()
    {
        //拿到turretData 做一下安全校验
        turretData = BuildManager.Instance.selectedTurretData;
        if (turretData == null || turretData.turretPrefab == null) return;

        //看看够不够钱 不够钱就不给建造
        if (BuildManager.Instance.IsEnough(turretData.cost)==false)
        {
            return;
        }

        //够钱就可以扣钱了
        BuildManager.Instance.ChangeMoney(-turretData.cost);

        //扣完钱就实例化炮台
        turretGO = InstantiateTurret(turretData.turretPrefab);
    }


    /// <summary>
    /// 实例化炮台具体方法
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    private GameObject InstantiateTurret(GameObject prefab)
    {
        //实例化炮台
        GameObject turretGo = GameObject.Instantiate(prefab, transform.position, Quaternion.identity);

        //建造粒子特效
        GameObject go = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity); 
        Destroy(go, 2);
        
        //返回回去
        return turretGo;
    }



    /// <summary>
    /// 鼠标在上面
    /// </summary>
    private void OnMouseEnter()
    {
        if (turretGO == null && EventSystem.current.IsPointerOverGameObject() == false)
        {
            GetComponent<MeshRenderer>().material.color = normalColor*0.3f;
        }
    }

    

    /// <summary>
    /// 鼠标离开
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

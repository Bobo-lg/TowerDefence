using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //单例
    public static BuildManager Instance { get; private set; }

    public TurretData standardTurretData;
    public TurretData missileTurretData;
    public TurretData laserTurretData;

    public TurretData selectedTurretData;

    public TextMeshProUGUI moneyText;
    private Animator moneyTextAnim;
    private int money = 1000;

    public UpgradeUI upgradeUI;
    private MapCube upgradeCube;

    
    private void Awake()
    {
        Instance = this; 

        //获取金钱Animator组件
        moneyTextAnim = moneyText.GetComponent<Animator>();
    }



    #region 供给炮台选择Toggle按钮使用
    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = standardTurretData;
        }
    }
    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
        }
    }
    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = laserTurretData;
        }
    }
    #endregion




    /// <summary>
    /// 金钱是否足够
    /// </summary>
    /// <param name="need"></param>
    /// <returns></returns>
    public bool IsEnough(int need)
    {
        if (need <= money)
        {
            return true;
        }
        else
        {
            MoneyFlicker(); //说明金钱不够 就要闪烁一下UI
            return false;
        }
    }


    /// <summary>
    /// 改变金钱数量
    /// </summary>
    /// <param name="value"></param>
    public void ChangeMoney(int value)
    {
        this.money += value;
        moneyText.text = "￥:"+money.ToString();
    }



    /// <summary>
    /// 播放金钱不够然后闪烁的动画
    /// </summary>
    private void MoneyFlicker()
    {
        moneyTextAnim.SetTrigger("flicker");
    }





    public void ShowUpgradeUI(MapCube cube, Vector3 position,bool isDisableUpgrade)
    {
        upgradeCube = cube;
        upgradeUI.Show(position, isDisableUpgrade);
    }
    public void HideUpgradeUI()
    {
        upgradeUI.Hide();
    }

    public void OnTurretUpgrade()
    {
        upgradeCube?.OnTurretUpgrade();
        HideUpgradeUI();
    }
    public void OnTurretDestroy()
    {
        upgradeCube?.OnTurretDestroy();
        HideUpgradeUI();
    }
}

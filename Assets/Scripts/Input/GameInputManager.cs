using System.Collections;
using System.Collections.Generic;
using TZY.Tool.Singleton;
using UnityEngine;


public class GameInputManager : Singleton<GameInputManager>
{
    private GameInputAction _gameInputAction; //获取输入配置文件

    protected override void Awake()
    {
        base.Awake();
        _gameInputAction = new GameInputAction();
    }


    private void OnEnable()
    {
        _gameInputAction.Enable();
    }

    private void OnDisable()
    {
        _gameInputAction.Disable();
    }


    /*
     * 输入配置说明：
     *     Movement：              WASD键       控制玩家移动
     *     CameraLook：            鼠标移动      控制第三人称摄像机
     *     Run：                   LShift       控制奔跑
     *     Climb：                 Q            攀爬 翻滚
     *     LAttack：               鼠标左键      普通攻击
     *     RParry：                鼠标右键      变招攻击
     *     Grab：                  F            处决
     *     Interaction：           E            交互
     *     Parry                   Space        格挡
     */


    public Vector2 Movement => _gameInputAction.GameInput.Movement.ReadValue<Vector2>();
}

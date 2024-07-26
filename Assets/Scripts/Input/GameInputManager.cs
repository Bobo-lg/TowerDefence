using System.Collections;
using System.Collections.Generic;
using TZY.Tool.Singleton;
using UnityEngine;


public class GameInputManager : Singleton<GameInputManager>
{
    private GameInputAction _gameInputAction; //��ȡ���������ļ�

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
     * ��������˵����
     *     Movement��              WASD��       ��������ƶ�
     *     CameraLook��            ����ƶ�      ���Ƶ����˳������
     *     Run��                   LShift       ���Ʊ���
     *     Climb��                 Q            ���� ����
     *     LAttack��               ������      ��ͨ����
     *     RParry��                ����Ҽ�      ���й���
     *     Grab��                  F            ����
     *     Interaction��           E            ����
     *     Parry                   Space        ��
     */


    public Vector2 Movement => _gameInputAction.GameInput.Movement.ReadValue<Vector2>();
}

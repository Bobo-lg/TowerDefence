using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ��ʱ������״̬
/// </summary>
public enum TimerState
{
    NOWORKING,  //δ��ʼ����
    WORKING,    //���ڹ���
    DONE        //���
}



public class GameTimer
{
    /*  
     *  1.��ʱʱ��
     *  2.��ʱ������ִ�е�����
     *  3.��ǰ��ʱ����״̬
     *  4.�Ƿ�ֹͣ��ǰ��ʱ��
     */


    private float _startTime;
    public Action _task;
    private TimerState _timerState;
    private bool _isStopTimer;



    //���캯�� ֻҪʵ������������һ�±���
    public GameTimer()
    {
        ResetTimer();
    }

    //1����ʼ��ʱ
    public void StartTimer(float time, Action task)
    {
        _startTime = time;
        _task = task;
        _timerState = TimerState.WORKING;
        _isStopTimer = false;
    }

    //2�����¼�ʱ��
    public void UpdateTimer()
    {
        if (_isStopTimer) return;

        _startTime -= Time.deltaTime;
        if (_startTime < 0)
        {
            _task?.Invoke();
            _timerState = TimerState.DONE;
            _isStopTimer = true;
        }
    }

    //3��ȷ����ʱ����״̬
    public TimerState GetTimerState() => _timerState;


    //4�����ö�ʱ��
    public void ResetTimer()
    {
        _startTime = 0f;
        _task = null;
        _timerState = TimerState.NOWORKING;
        _isStopTimer = true;
    }

}

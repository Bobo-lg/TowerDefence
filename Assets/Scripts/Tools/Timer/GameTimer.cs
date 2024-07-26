using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 计时器工作状态
/// </summary>
public enum TimerState
{
    NOWORKING,  //未开始工作
    WORKING,    //正在工作
    DONE        //完成
}



public class GameTimer
{
    /*  
     *  1.计时时长
     *  2.计时结束后执行的任务
     *  3.当前计时器的状态
     *  4.是否停止当前计时器
     */


    private float _startTime;
    public Action _task;
    private TimerState _timerState;
    private bool _isStopTimer;



    //构造函数 只要实例化就先重置一下变量
    public GameTimer()
    {
        ResetTimer();
    }

    //1、开始计时
    public void StartTimer(float time, Action task)
    {
        _startTime = time;
        _task = task;
        _timerState = TimerState.WORKING;
        _isStopTimer = false;
    }

    //2、更新计时器
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

    //3、确定定时器的状态
    public TimerState GetTimerState() => _timerState;


    //4、重置定时器
    public void ResetTimer()
    {
        _startTime = 0f;
        _task = null;
        _timerState = TimerState.NOWORKING;
        _isStopTimer = true;
    }

}

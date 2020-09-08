// Sleep.cs, 自定义节点：睡眠

using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Sleep : Action
{
    // 睡眠时间。会在行为树编辑器中赋值
    public SharedFloat sleepTime;

    private float m_sleepTime;
    private float m_startTime;

    public override void OnStart()
    {
        m_startTime = Time.time;
        m_sleepTime = (float)sleepTime.GetValue();
    }


    public override TaskStatus OnUpdate()
    {
        if (m_startTime + m_sleepTime < Time.time)
        {
            return TaskStatus.Success;
        }
        Debug.Log("I am Sleeping");
        return TaskStatus.Running;
    }
}
// Runner.cs

using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;


public class Runner : MonoBehaviour
{

    private BehaviorTree m_bt;

    void Start()
    {
        // 动态添加行为树
        var bt = gameObject.AddComponent<BehaviorTree>();
        // 加载行为树资源
        var extBt = Resources.Load<ExternalBehaviorTree>("Behavior");
        bt.StartWhenEnabled = false;
        bt.RestartWhenComplete = true;
        // 设置行为树
        bt.ExternalBehavior = extBt;
        bt.EnableBehavior();
        // 把行为树对象缓存起来，后面需要通过它来设置变量和发送时间
        m_bt = bt;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 吃红烧牛肉面
            m_bt.SetVariableValue("food", "红烧牛肉面");
            m_bt.SendEvent("Eat");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            // 睡10000秒
            m_bt.SetVariableValue("sleepTime", 10000f);
            m_bt.SendEvent("Sleep");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            // 地震啦
            m_bt.SendEvent("EarthQuake");
        }
    }
}
// 消息分发器
// C# this扩展 需要静态类
// 教程地址:http://liangxiegame.com/post/5/

using UnityEngine;
using QFramework;
using System;
using System.Collections.Generic;

public static class MsgDispatcher
{
    private class LogicMsgHandler
    {
        public readonly IMsgReceiver receiver;
        public readonly Action<object[]> callback;

        public LogicMsgHandler(IMsgReceiver receiver, Action<object[]> callback)
        {
            this.receiver = receiver;
            this.callback = callback;
        }
    }

    // 每个消息名字维护一组消息捕捉器
    static readonly Dictionary<string, List<LogicMsgHandler>> mMsgHandlerDict = new Dictionary<string, List<LogicMsgHandler>>();

    // 注册消息
    public static void RegisterLogicMsg(this IMsgReceiver self, string msgName, Action<object[]> callback)
    {
        if(string.IsNullOrEmpty(msgName)){
            Debug.LogError("RegisterMsg:" + msgName + "is Null or Empty");
            return;
        }
        if(callback == null){
            Debug.LogError("RigisterMsg:" + msgName + "callback is Null");
            return;
        }
        if(!mMsgHandlerDict.ContainsKey(msgName)){
            mMsgHandlerDict[msgName] = new List<LogicMsgHandler>();
        }

        var handlers = mMsgHandlerDict[msgName];
        // 防止重复注册消息
        foreach(var handler in handlers){
            if(handler.receiver == self && handler.callback == callback){
                Debug.LogError("RegisterMsg:" + msgName + "already Register");
                return;
            }
        }

        handlers.Add(new LogicMsgHandler(self, callback));
    }

    // 发送消息
    public static void SendLogicMsg(this IMsgSender sender, string msgName, params object[] paramList)
    {
        if(string.IsNullOrEmpty(msgName)){
            Debug.LogError("SendMsg is Null or Empty");
            return;
        }
        if(!mMsgHandlerDict.ContainsKey(msgName)){
            Debug.LogError("SengMsg is UnRegister");
            return;
        }

        var handlers = mMsgHandlerDict[msgName];
        var handlerCount = handlers.Count;

        // 从后向前遍历,避免删除后索引值发生变化
        for(var index = handlerCount - 1; index >= 0; --index){
            var handler = handlers[index];
            if(handler.receiver != null){
                handler.callback(paramList);
            }
            else{
                handlers.Remove(handler);
            }
        }
    }
}
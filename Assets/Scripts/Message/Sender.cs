using UnityEngine;

namespace QFramework.Example
{
    public class Sender : MonoBehaviour, IMsgSender
    {
        void Update() {
            this.SendLogicMsg("Receiver Show Str", "你好", "世界");    
        }
    }
}
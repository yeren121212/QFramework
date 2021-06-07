using UnityEngine;

namespace QFramework.Example
{
    public class Receiver : MonoBehaviour, IMsgReceiver {
        private void Awake() {
            this.RegisterLogicMsg("Receiver Show Str", ReceiveMsg);    
        }

        private void ReceiveMsg(object[] args)
        {
            foreach(var arg in args)
            {
                Debug.LogError(arg);
            }
        }
    }
}
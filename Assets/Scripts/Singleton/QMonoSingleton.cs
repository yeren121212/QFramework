using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
	需要使用Unity生命周期的单例模式
 */
namespace QFramework
{
	public abstract class QMonoSingleton<T> : MonoBehaviour where T :QMonoSingleton<T>
	{
		protected static T instance = null;

		public static T Instance()
		{
			if(instance == null)
			{
				instance = FindObjectOfType<T>();

				if(FindObjectsOfType<T>().Length > 1){
					// QPrint.FrameworkError("More than 1.");
					Debug.LogError("More than 1.");
					return instance;
				}

				if (instance == null)
				{
					string instanceName = typeof(T).Name;
					Debug.LogError("Instance Name: " + instanceName);
					GameObject instanceGO = GameObject.Find(instanceName);

					if(instanceGO == null) instanceGO = new GameObject(instanceName);
					instance = instanceGO.AddComponent<T>();
					DontDestroyOnLoad(instanceGO);
					Debug.LogError("Add New Singleton " + instance.name + "in Game.");
				}
				else
				{
					Debug.LogError("Already exist: " + instance.name);
				}
			}

			return instance;
		}

		protected virtual void OnDestroy()
		{
			instance = null;	
		}
	}
}
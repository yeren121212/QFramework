using QFramework;
using UnityEngine;

// 继承Singleton
// 实现非public的构造方法

public class XXManager : Singleton<XXManager>
{
	private XXManager()
	{
		Debug.Log("XXManager构造函数");
	}

	public void Func()
	{
		Debug.Log("XXManager:Func");
	}

}
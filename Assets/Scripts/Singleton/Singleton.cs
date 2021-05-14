using System;
using System.Reflection;

namespace QFramework
{
	public abstract class Singleton<T> where T : Singleton<T> {
		protected static T instance = null;

		protected Singleton() {}

		public static T Instance()
		{
			if(instance == null){
				// 获取所有非public的构造函数
				ConstructorInfo[] ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
				// 获取无参的构造方法
				ConstructorInfo ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
				if(ctor == null){
					throw new Exception("Non-public ctor() not found!");
				}
				// 调用构造方法
				instance = ctor.Invoke(null) as T;
			}

			return instance;
		}
	}
}

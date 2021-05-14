using UnityEngine;
using System;

#if UNITY_EDITOR
	using UnityEditor;
#endif

namespace QFramework
{
	public static class LogFileName
	{
		#if UNITY_EDITOR
			[MenuItem("QFramework/生成UnityPackage名字")]
		#endif

		private static void GenerateUnityPackageName(){
			Debug.Log("QFrameword_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
		}
	}
}
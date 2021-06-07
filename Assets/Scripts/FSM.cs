using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM {
	public delegate void FSMTranslationCallback();

	// 状态类
	public class FSMState
	{
		public string name;
		public FSMState(string name)
		{
			this.name = name;
		}
		public Dictionary<string, FSMTranslation> translationDict = new Dictionary<string, FSMTranslation>();
	}

	// 跳转条件类
	public class FSMTranslation
	{
		public string name;
		public FSMState fromState;
		public FSMState toState;
		public FSMTranslationCallback callback;
		public FSMTranslation(string name, FSMState fromState, FSMState toState, FSMTranslationCallback callback)
		{
			this.name = name;
			this.fromState = fromState;
			this.toState = toState;
			this.callback = callback;
		}
	}

	private FSMState curState;	// 当前状态
	private Dictionary<string, FSMState> stateDict = new Dictionary<string, FSMState>();

	public void AddState(FSMState state)
	{
		stateDict[state.name] = state;
	}
	public void AddTranslation(FSMTranslation translation)
	{
		stateDict[translation.fromState.name].translationDict[translation.name] = translation;
	}

	// 起始状态
	public void Start(FSMState state)
	{
		curState = state;
	}

	// 状态跳转
	public void HandleEvent(string name)
	{
		if(curState != null && curState.translationDict.ContainsKey(name))
		{
			Debug.LogError("fromState:" + curState.name);
			curState.translationDict[name].callback();
			curState = curState.translationDict[name].toState;
			Debug.LogError("toState:" + curState.name);
		}
	}
}

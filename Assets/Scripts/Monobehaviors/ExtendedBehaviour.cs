using UnityEngine;
using System.Collections;
using System;
using DG.Tweening;
 

public static class ExtendedBehaviour{
	public static Coroutine WaitSeconds(this MonoBehaviour mono, YieldInstruction seconds, Action action)
	{
		return mono.StartCoroutine(_waitSeconds(seconds, action));
	}

	public static Coroutine WaitSeconds(this MonoBehaviour mono, float seconds, Action action)
	{
		return mono.StartCoroutine(_waitSeconds(new WaitForSeconds(seconds), action));
	}

	public static Coroutine WaitUntil(this MonoBehaviour mono, Func<bool> parameter, Action action)
	{
		return mono.StartCoroutine(_waitUntil(parameter, action));
	}


	public static int RandomChance(float[] chances, double presetChance = 0)
	{
		float totalChance = 0;
		for(int i = 0; i < chances.Length; i++)
		{
			totalChance += chances[i];
		}
		presetChance *= totalChance;
		totalChance = 0;
		for(int i = 0; i < chances.Length; i++)
		{
			totalChance += chances[i];
			if(totalChance > presetChance) return i;
		}
		return chances.Length -1;
	}

	

	public static void SetX(this Transform trans, float x, bool isLocal = false)
	{
		if(!isLocal) trans.position = new Vector3(x, trans.position.y, trans.position.z);
		else trans.localPosition = new Vector3(x, trans.localPosition.y, trans.localPosition.z);
	}
	public static void SetY(this Transform trans, float y, bool isLocal = false)
	{
		if(!isLocal) trans.position = new Vector3(trans.position.x, y, trans.position.z);
		else trans.localPosition = new Vector3(trans.localPosition.x, y, trans.localPosition.z);
	}
	public static void SetZ(this Transform trans, float z, bool isLocal = false)
	{
		if(!isLocal) trans.position = new Vector3(trans.position.x, trans.position.y, z);
		else trans.localPosition = new Vector3(trans.localPosition.x, trans.localPosition.y, z);
	}

	public static string GetPath(this Transform trans, Transform toTransform = null)
	{
		string result = "";

		var loopTrans = trans;
		while(loopTrans != null && loopTrans != toTransform )
		{
			result = "/" + loopTrans.gameObject.name + result;
			loopTrans = loopTrans.parent;
		}
		return result.Trim('/');
	}

	public static T GetComponentPrefab<T>(this Component component, T obj, Component pref) where T:Component
	{
		return component.transform.Find(obj.transform.GetPath(pref.transform)).GetComponent<T>();
	}

	public static void TweenTo(this RectTransform trans, RectTransform target, float duration, RectTransform from = null)
	{
		if(from != null)
		{
			trans.anchorMax = from.anchorMax;
			trans.anchorMin = from.anchorMin;
			trans.anchoredPosition = from.anchoredPosition;
			trans.rotation = from.rotation;
			trans.sizeDelta = from.sizeDelta;
		}
		trans.DOAnchorMax(target.anchorMax, duration);
		trans.DOAnchorMin(target.anchorMin, duration);
		trans.DOAnchorPos(target.anchoredPosition, duration);
		trans.DORotateQuaternion(target.rotation, duration);
		trans.DOSizeDelta(target.sizeDelta, duration);

	}

	static IEnumerator _waitSeconds(YieldInstruction time, Action callback)
	{
		//Debug.Log("wait started");
		yield return time;
		callback();
	}

	static IEnumerator _waitUntil(Func<bool> parameter, Action callback)
	{
		//Debug.Log("wait started");
		yield return new WaitUntil(parameter);
		callback();
	}



	


}


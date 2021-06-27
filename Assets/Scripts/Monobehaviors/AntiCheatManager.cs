using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AntiCheatManager : MonoBehaviour
{

    private static AntiCheatManager m_sInstance;
    public static AntiCheatManager Instance
    {
        get
        {
            // if ((UnityEngine.Object) AntiCheatManager.m_sInstance == (UnityEngine.Object) null)
            // DebugManager.Log("Attempted Get on null instance :: DecorationManager");
            return AntiCheatManager.m_sInstance;
        }
    }
    
    private void Awake()
    {
        // DebugManager.Log("ACManager::Awake()");
        if ((UnityEngine.Object) AntiCheatManager.m_sInstance != (UnityEngine.Object) null)
        {
            UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.gameObject);
        }
        else
        {
            AntiCheatManager.m_sInstance = this;
//            ConstantManager.Instance.Register((Action) (() => this.m_nMaxClicks = ConstantManager.Instance.Get<int>("MaxClicksPerSecond", this.m_nMaxClicks)));
        }
    }
    


  
    public static void CheckHack(object protectedObject, int hashCode)
    {
        if (hashCode == 0 || protectedObject == null /*||  GameManager.instance == null ||*/ || AntiCheatManager.Hash(protectedObject) == hashCode)
        return;
        // FirstTimeLoader._instance.StopSave();
        // PlayfabPlayerDataManager.Logout();
    }

    public static int Hash(object source)
    {
        return source.GetType() == typeof (int) ? (int) source * 2 - 123 : source.GetHashCode();
    }
}

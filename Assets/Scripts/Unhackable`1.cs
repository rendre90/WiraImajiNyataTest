using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unhackable<T>
{
    private int m_nHash;
    private T m_value;

    public T Value
    {
        get
        {
        AntiCheatManager.CheckHack((object) this.m_value, this.m_nHash);
        return this.m_value;
        }
        set
        {
        AntiCheatManager.CheckHack((object) this.m_value, this.m_nHash);
        this.m_value = value;
        this.m_nHash = AntiCheatManager.Hash((object) this.m_value);
        }
    }

    public static implicit operator T(Unhackable<T> original)
    {
        return original.Value;
    }

    public static implicit operator Unhackable<T>(T original)
    {
        return new Unhackable<T>() { Value = original };
    }

    public override string ToString()
    {
        return this.m_value.ToString();
    }
}

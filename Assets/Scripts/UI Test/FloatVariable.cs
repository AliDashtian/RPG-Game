using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    public float Value;
    public string Key;

    public event Action OnValueChanged;

    private void OnEnable()
    {
        Value = PlayerPrefs.GetFloat(Key, 0);
    }

    public void InvokeOnValueChanged()
    {
        PlayerPrefs.SetFloat(Key, Value);
        OnValueChanged?.Invoke();
    }
}

using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UI/StringVariable")]
public class StringVariable : ScriptableObject
{
    public event Action<string> OnValueChanged;

    private string Value;

    private void OnEnable()
    {
        Value = string.Empty;
    }

    public void InvokeOnValueChanged(string value)
    {
        OnValueChanged?.Invoke(value);
    }
}

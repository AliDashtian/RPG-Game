using UnityEngine;
using UnityEngine.EventSystems;

public class StringVariableSetter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public enum ValueType { HierarchyName, ObjectName, ObjectDescription}
    public ValueType valueType;
    public StringVariable Variable;

    private string value;

    private void Start()
    {
        SetValue();
    }

    void SetValue()
    {
        switch (valueType)
        {
            case ValueType.HierarchyName:
                value = transform.name;
                break;
            case ValueType.ObjectName:
                value = GetComponent<ItemView>().ViewInfo.Name;
                break;
            case ValueType.ObjectDescription:
                value = GetComponent<ItemView>().ViewInfo.Description;
                AddDescriptionPrefix();
                break;
            default:
                value = string.Empty;
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Variable.InvokeOnValueChanged(value);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Variable.InvokeOnValueChanged("");
    }

    private void AddDescriptionPrefix()
    {
        if (valueType == ValueType.ObjectDescription) 
        {
            value = "Description : " + value;
        }
    }
}

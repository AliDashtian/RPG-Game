using UnityEngine;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour
{
    public StringVariable Variable;
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        Variable.OnValueChanged += SetText;
    }

    private void OnDisable()
    {
        Variable.OnValueChanged -= SetText;
    }

    void SetText(string value)
    {
        text.text = value;
    }
}

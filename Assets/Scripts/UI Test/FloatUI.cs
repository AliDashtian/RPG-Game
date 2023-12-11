using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatUI : MonoBehaviour
{
    public FloatVariable Variable;

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();

        UpdateText();

        Variable.OnValueChanged += UpdateText;
    }

    void UpdateText()
    {
        text.text = Variable.Value.ToString();
    }
}

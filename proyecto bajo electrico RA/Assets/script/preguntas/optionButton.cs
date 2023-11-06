using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]

public class optionButton : MonoBehaviour
{
    private Text m_text = null;
    private Button m_button = null;
    private Image m_image = null;
    private Color m_originalColor = Color.black;

    public opcion Opcion { get; set; }

    private void Awake()
    {
        m_button = GetComponent<Button>();
        m_image = GetComponent<Image>();
        m_text = transform.GetChild(0).GetComponent<Text>();
        m_originalColor = m_image.color;
    }
    public void construc(opcion opcion, Action<optionButton> callback)
    {
        m_text.text = opcion.text;
        m_button.enabled = true;
        m_image.color = m_originalColor;
        Opcion = opcion;
        m_button.onClick.AddListener(delegate
        {
            callback(this);
        }
        );
    }

    public void SetColor(Color c)
    {
        m_button.enabled = false;
        m_image.color = c;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class interfaz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI t;
    [SerializeField] Image i;
    [SerializeField] Sprite org;
    [SerializeField] Sprite dif;
    [SerializeField] string orgTexto;
    [SerializeField] string intercambio;
    private void OnEnable()
    {
        if(t==null) t = GetComponentInChildren<TextMeshProUGUI>();
        if (i==null) i = GetComponent<Image>();
        t.text = orgTexto;
        i.sprite = org;
    }
    private void OnMouseEnter()
    {
        t.text = intercambio;
        i.sprite= dif;
    }
    private void OnMouseExit()
    {
        t.text = orgTexto;
        i.sprite = org;
    }
}

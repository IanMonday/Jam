using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandera : MonoBehaviour
{
    [SerializeField] Animator an;
    [SerializeField] bool Con;
    private void Start()
    {
        if (Con) an.SetTrigger("Con");
    }
    public void Conseguido()
    {
        an.SetTrigger("Conseguir");
    }
}

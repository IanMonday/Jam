using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinema : MonoBehaviour
{
    [SerializeField] float t;
    [SerializeField] Menu m;
    private void Start()
    {
        StartCoroutine(cine());
        m = FindObjectOfType<Menu>();
    }
    IEnumerator cine()
    {
        yield return new WaitForSeconds(t);
        m.Siguiente();
    }
}

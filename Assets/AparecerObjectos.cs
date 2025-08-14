using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
public class AparecerObjectos : MonoBehaviour
{
    [SerializeField] List<GameObject> objectos;
    [SerializeField] GameObject []referencia;
    [SerializeField] float frecuencia;
    [SerializeField] bool randomizarY;
    [SerializeField] int minX, maxX;
    [SerializeField] int minY, maxY;
    [SerializeField] int maximo;
    private float frecuenciaOrg;
    private int numRef;
    private void Start()
    {
        Agregar(maximo);
        numRef = 0;
        frecuenciaOrg = frecuencia;
    }
    private void Update()
    {
        if(frecuencia<=0)
        {
            frecuencia = frecuenciaOrg;
            GameObject b=Requimiento();
            if (b == null) return;
            if(!randomizarY)b.transform.position = new Vector2(Random.Range(minX, maxX), maxY);
            else b.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
        if (frecuencia > 0) frecuencia -= Time.deltaTime;
    }
    public void Agregar(int cantidad)
    {
        for (int x = 0; x < cantidad; x++)
        {
            GameObject b = Instantiate(referencia[numRef], this.transform);
            b.SetActive(false);
            objectos.Add(b);
            if (numRef < referencia.Length - 1) numRef++;
            else numRef = 0;
        }
    }
    public GameObject Requimiento()
    {
        for (int x = 0; x < objectos.Count; x++)
        {
            if (!objectos[x].activeSelf)
            {
                objectos[x].SetActive(true);
                objectos[x].transform.DOScale(new Vector2(objectos[x].transform.localScale.x +0.25f, objectos[x].transform.localScale.y+0.25f), 0.25f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InQuad);
                return objectos[x];
            }
        }
        return null;
    }
}

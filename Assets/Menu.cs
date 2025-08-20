using Code.Audio;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [SerializeField] bool fadeInicio;
    [SerializeField] bool fadeFinal;
    [SerializeField] Image panel;
    float org;
    private void Awake()
    {
        Time.timeScale = 1;
        if (fadeInicio)
        {
            Color a = panel.color;
            a.a = 1;
            panel.color = a;
            panel.DOFade(0, 0.5f).SetDelay(0.5f);
        }
    }
    public void Siguiente()
    {
        AudioManager.PlayAudio(AudioID.Click, this);
        StartCoroutine(Sig());
    }
    public void Reinicio()
    {
        StartCoroutine(Reini());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reini());
            this.enabled = false;
        }
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Pausa()
    {
        Time.timeScale = 0;
    }
    public void Reanudar()
    {
        Time.timeScale = 1;
    }
    public void Volver()
    {
      SceneManager.LoadScene(0);
    }

    IEnumerator Sig()
    {
        if (fadeFinal) panel.DOFade(1, 0.75f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Reini()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

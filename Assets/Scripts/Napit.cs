using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Napit : MonoBehaviour
{
    public UnityEvent punainen;
    public UnityEvent vihrea;
    public UnityEvent keltainen;
    private MasterInput input;

    void Awake()
    {
        input = new MasterInput();
        input.Enable();
    }

    void Update()
    {
        if (input.UI.Punainen.triggered) punainen.Invoke();
        if (input.UI.Vihrea.triggered) vihrea.Invoke();
        if (input.UI.Keltainen.triggered) keltainen.Invoke();
    }

    public void Pelaa()
    {
        SceneManager.LoadScene("Peli");
    }

    public void Poistu()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    public void Valikko()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Valikko");
    }

    public void JatkaPelia(GameObject pauseValikko)
    {
        Time.timeScale = 1;
        pauseValikko.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pelaaja : Auto
{
    public TextMeshProUGUI kierrosTeksti;
    public GameObject loppuruutu;
    public TextMeshProUGUI lopputeksti;
    public GameObject havioruutu;
    public GameObject pauseValikko;
    private MasterInput input;

    // Start is called before the first frame update
    void Awake()
    {
        input = new MasterInput();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    // Update is called once per frame
    protected override Vector2 GetSuunta()
    {
        return input.Pelaaja.Liikkuminen.ReadValue<Vector2>();
    }

    void Update()
    {
        if (input.UI.Pause.triggered)
        {
            if (pauseValikko.activeSelf)
            {
                pauseValikko.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseValikko.SetActive(true);
                Time.timeScale = 0;
            }
        }
        kierrosTeksti.text = "Kierros " + Mathf.Min(kierros, Maali.Instance.kierrostenMaara) +
        "/" + Maali.Instance.kierrostenMaara;
        if (kierros > Maali.Instance.kierrostenMaara)
        {
            kierrosTeksti.gameObject.SetActive(false);
            loppuruutu.SetActive(true);
            lopputeksti.text = "" + Maali.Instance.Monesko(this);
        }
    }

    public override void OnAutoPoistetaan()
    {
        kierrosTeksti.gameObject.SetActive(false);
        havioruutu.SetActive(true);
    }
}

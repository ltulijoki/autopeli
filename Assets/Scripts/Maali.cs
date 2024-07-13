using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Maali : MonoBehaviour
{
    public int kierrostenMaara;
    [HideInInspector]
    public bool kaynnissa;
    private List<Auto> autot = new();
    private List<Auto> maalissa = new();
    public bool KaikkiMaalissa
    {
        get
        {
            return maalissa.Count >= autot.Count;
        }
    }
    public static Maali Instance { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.TryGetComponent<Auto>(out var auto)) return;
        auto.kierros++;
        if (auto.kierros > kierrostenMaara)
        {
            maalissa.Add(auto);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LisaaAuto(Auto auto)
    {
        autot.Add(auto);
    }

    public void PoistaAuto(Auto auto)
    {
        autot.Remove(auto);
        auto.OnAutoPoistetaan();
        Destroy(auto.gameObject);
    }

    public int Monesko(Auto auto)
    {
        return maalissa.IndexOf(auto) + 1;
    }
}

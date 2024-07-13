using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vastustaja : Auto
{
    private List<Vector2> pisteet = new();
    private int piste = 0;

    // Start is called before the first frame update
    void Awake()
    {
        Transform t = GameObject.Find("Pisteet").transform;
        for (int i = 0, maara = t.childCount; i < maara; i++)
        {
            pisteet.Add(PoistaY(t.GetChild(i).position));
        }
    }

    // Update is called once per frame
    protected override Vector2 GetSuunta()
    {
        Vector2 seuraava = pisteet[piste];
        float erotus = Mathf.Abs((PoistaY(transform.position) - seuraava).magnitude);
        Vector2 palautus = Vector2.up;
        if (erotus < 25)
        {
            piste = (piste + 1) % pisteet.Count;
        }
        return palautus;
    }

    private static Vector2 PoistaY(Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Auto : MonoBehaviour
{
    public float maxNopeus;
    public float kiihtyvyys;
    public float kaantyvyys;
    [HideInInspector]
    public int kierros;
    protected float nopeus;
    protected Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Maali.Instance.LisaaAuto(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Maali.Instance.kaynnissa || kierros > Maali.Instance.kierrostenMaara) return;
        if (rb.position.y < -10) Maali.Instance.PoistaAuto(this);

        Vector2 suunta = GetSuunta();

        float y = suunta.y * kiihtyvyys;
        if (suunta.y < 0.5f && suunta.y >= 0) y = -0.5f * kiihtyvyys;
        nopeus += y;
        nopeus = Mathf.Min(Mathf.Max(nopeus, 0), maxNopeus);
        rb.MovePosition(rb.position + (nopeus * Time.fixedDeltaTime * transform.forward));

        float x = suunta.x;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(Time.fixedDeltaTime * x * kaantyvyys * Vector3.up));
    }

    protected abstract Vector2 GetSuunta();

    public virtual void OnAutoPoistetaan()
    { }
}

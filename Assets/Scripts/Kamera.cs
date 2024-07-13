using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Kamera : MonoBehaviour
{
    public string piilota;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer(piilota));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

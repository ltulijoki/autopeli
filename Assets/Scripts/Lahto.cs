using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lahto : MonoBehaviour
{
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Kaynnista());
    }

    IEnumerator Kaynnista()
    {
        yield return new WaitForSeconds(1);
        text.text = "2";
        yield return new WaitForSeconds(1);
        text.text = "1";
        yield return new WaitForSeconds(1);
        Maali.Instance.kaynnissa = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

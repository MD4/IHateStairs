using UnityEngine;
using System.Collections;

public class glowing : MonoBehaviour {

    public float duration = 1.0F;
    public Light lt;

    private float startRandom;
   

    void Start()
    {
        lt = GetComponent<Light>();
        startRandom = Random.Range(0.0F, 10000.0F);
    }

    void Update()
    {
        float phi = (startRandom + Time.time / 5.12F) / duration * 2 * Mathf.PI;
        float phi2 = (startRandom + Time.time / 12.6F) / (duration / 3.76F) * 2 * Mathf.PI;
        float phi3 = (startRandom + Time.time / 7.323F) / (duration / 12.94F) * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * Mathf.Sin(phi2) * Mathf.Cos(phi3) * 0.25F + 1F;
        lt.intensity = amplitude;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColor : MonoBehaviour {

    public float baseSize = 1f;

    void Start ()
    {
        GenerateColor();
	}

    void Update()
    {
        float animation = baseSize + Mathf.Sin(Time.time * 8f) * baseSize / 7f;
        transform.localScale = Vector3.one * animation;
    }
	public void GenerateColor ()
    {
        GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
    }

    public void Reset ()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.white;
    }
}

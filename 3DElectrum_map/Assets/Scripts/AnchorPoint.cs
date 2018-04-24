using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorPoint : MonoBehaviour {

    public float anchorAtlasX, anchorAtlasZ, anchorAtlasI, anchorAtlasJ, pixelsPerMeter;

    // Use this for initialization
    void Start()
    {
        GameObject.Find("AnchorPoint").GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

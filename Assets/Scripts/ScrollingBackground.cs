using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 0.1f;  
    private Material mat;    
    private Vector2 offset = Vector2.zero;   

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;   
        offset = mat.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += speed * Time.deltaTime;  
        mat.SetTextureOffset("_MainTex", offset);
    }
}

//using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class Cherry : MonoBehaviour
{

    private Vector2 size = new Vector2(1f, 1f);
    public int richness;
    public int minRichness = -1;
    public int maxRichness = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void Respawn() {
        //RectTransform parentCanvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        //Vector2 canvasSize = new Vector2(parentCanvas.rect.width, parentCanvas.rect.height);
        //Vector2 tempPos;
        //tempPos.x = Random.Range(parentCanvas.position.x, ((canvasSize.x + parentCanvas.position.x) / size.x));
        //tempPos.y = Random.Range(parentCanvas.position.y, ((canvasSize.y + parentCanvas.position.y) / size.y));
        //transform.position = tempPos;
        richness = Random.Range(minRichness, maxRichness);
        Vector2 tempPos;
        tempPos.x = Random.Range(-6, 6);
        tempPos.y = Random.Range(-3, 3);
        transform.position = tempPos;
    }
  
}

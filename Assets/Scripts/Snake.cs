using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private int speed = 4;
    private Vector2 size = new Vector2(1f, 1f);
    private GameObject[] Body;
    private Vector2 destination = Vector2.right;
    private float timeCount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount * speed >= 1) {
            timeCount = 0;
            Vector2 tempPos = transform.position;
            tempPos.x += destination.x * size.x;
            tempPos.y += destination.y * size.y;
            transform.position = tempPos;
        }
        Vector2 tempVel;
        tempVel.x = Input.GetAxisRaw("Horizontal");
        tempVel.y = Input.GetAxisRaw("Vertical");
        if (tempVel.magnitude > 0 && tempVel.magnitude <= 1) {
            destination = tempVel;
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision!");
    }
}

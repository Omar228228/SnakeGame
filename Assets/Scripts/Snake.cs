using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private int speed = 4;
    private Vector2 size = new Vector2(1f, 1f);
    private List<GameObject> Body = new List<GameObject>();
    private Vector2 destination = Vector2.right;
    private float timeCount;
    private Vector2 tempVel = new Vector2();
    private Camera mainCamera;

    public GameObject bodyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount * speed >= 1) {
            if (tempVel.magnitude > 0 && tempVel.magnitude <= 1 && tempVel.normalized != -destination.normalized)
            {
                destination = tempVel;
            }
            timeCount = 0;
            if (Body.Count > 0)
            {
                for (int i = 0; i < Body.Count - 1; i++)
                {
                    Body[Body.Count - i - 1].transform.position = Body[Body.Count - i - 2].transform.position;
                    Body[Body.Count - i - 1].GetComponent<BoxCollider2D>().enabled = true;
                }
                //Debug.Log(Body.Count);//
                Body[0].transform.position = transform.position - Vector3.back;
                
            }
            Vector2 tempPos = transform.position;
            tempPos.x += destination.x * size.x;
            tempPos.y += destination.y * size.y;
            //if (tempPos.x < mainCamera.rect.x || tempPos.x > mainCamera.rect.xMax) {
            //    Debug.Log("Out of area x");
            //    tempPos.x = ((tempPos.x - mainCamera.rect.x) / mainCamera.rect.width) - (int)((tempPos.x - mainCamera.rect.x) / mainCamera.rect.width); 
            //}
            //if (tempPos.y < mainCamera.rect.y || tempPos.y > mainCamera.rect.yMin)
            //{
            //    Debug.Log("Out of area y");
            //    tempPos.y = ((tempPos.y - mainCamera.rect.y) / mainCamera.rect.height) - (int)((tempPos.y - mainCamera.rect.y) / mainCamera.rect.height);
            //}
            transform.position = new Vector3(tempPos.x, tempPos.y, -1);

        }
        Vector2 tempVel2; 

        tempVel2.x = Input.GetAxisRaw("Horizontal");
        tempVel2.y = Input.GetAxisRaw("Vertical");

        if (tempVel2.magnitude > 0 && tempVel2.magnitude <= 1 && tempVel2.normalized != -tempVel.normalized)
        {
            tempVel = tempVel2;
        }


    }



    private void GrowUp(int n) {
        for(int i = 0; i < n; i++)
        {

            GameObject body = Instantiate(bodyPrefab, transform.position - Vector3.back, transform.rotation);
            Body.Add(body);
            body.transform.parent = transform.parent;

        }
        

    }
    private void GrowDown(int n)
    {       
        for (int i = 0; i > n; i--)
        {
            GameObject body = Body[Body.Count - 1];
            Body.RemoveAt(Body.Count - 1);
            Destroy(body);
        }


    }

    private void GameOver() {

        for (int i = 0; i < Body.Count; i++) {
            Destroy(Body[i]);
        }
        Body = new List<GameObject>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Body")
        {
            GameOver();
        }
        else {
            
            Cherry cherry = collision.collider.GetComponent<Cherry>();
            if (cherry.richness > 0) {
                
                GrowUp(cherry.richness);
            }
            else
            {
                GrowDown(cherry.richness);
            }
            //if( хв≥ст, отруйну €году)
            cherry.Respawn();


        }

    }

}

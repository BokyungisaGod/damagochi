using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class store : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Soldout();
        }
        void Soldout()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //if (hit.collider == CompareTag("salad")
            //{

            //}
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAroundSpace : MonoBehaviour
{
   
     void Update()
    {

        WrapAround();
    }

    void WrapAround()
    {
        Vector3 position = transform.position;
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(position);

        if (viewportPosition.x > 1)
        {
            position.x = Camera.main.ViewportToWorldPoint(Vector3.zero).x-10;
         
        }
        else if (viewportPosition.x < 0)
        {
            position.x = Camera.main.ViewportToWorldPoint(Vector3.one).x +10;
        }

        if (viewportPosition.y > 1)
        {
            position.y = Camera.main.ViewportToWorldPoint(Vector3.zero).y-6;
        }
        else if (viewportPosition.y < 0)
        {
            position.y = Camera.main.ViewportToWorldPoint(Vector3.one).y +6;
           
        }

        transform.position = position;
    }
}

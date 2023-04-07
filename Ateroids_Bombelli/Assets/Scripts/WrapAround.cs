using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0 || pos.x > 1 || pos.y < 0 || pos.y > 1)
        {
            pos.x = 1 - pos.x;
            pos.y = 1 - pos.y;
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }
}

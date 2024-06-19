using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    void Start() {
        // caculate aspect
        float targetAspect = 9f / 16f;  
        float currentAspect = (float)Screen.width / Screen.height;

        float size = Camera.main.orthographicSize * ( targetAspect/ currentAspect);
        Camera.main.orthographicSize = size;
    }
}


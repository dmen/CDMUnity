using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTouch : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    string n;

    void FixedUpdate()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit, 1500))
                {
                    n = hit.collider.name;
                    if(n == "exitSign" || n == "exitSign2")
                    {
                        SceneManager.LoadScene(0);
                    }
                }
            }
        }
    }
}

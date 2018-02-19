using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Used in scene: Hall
 * Attached to both of the main exit sign objects
 * allows exiting by clicking the sign - ie when in Phone mode
 */
public class ExitTouch : MonoBehaviour
{
    Manager theManager;
    RaycastHit hit;
    Ray ray;
    string n;

    private void Start()
    {
        theManager = GameObject.Find("theManager").GetComponent<Manager>();
    }


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
                        theManager.exitSignExit();
                    }
                }
            }
        }
    }
}

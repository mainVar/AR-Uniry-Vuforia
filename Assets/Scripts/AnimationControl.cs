using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour { 

    string objName;
    public Animator Anim;

    // Use this for initialization
    void Start()
    {
        
        Anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                objName = Hit.transform.name;
                switch (objName)
                {
                    case "Wolf":
                      Anim.SetBool("WolfIsRun", true);

                        Invoke("BaseState", 15f);
                        break;
                    default:
                      break;

                }
            }

        }
    }
    private void BaseState()
    {
        Anim.SetBool("WolfIsRun", false);

        return;
    }
}

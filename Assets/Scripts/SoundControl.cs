using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour {

    public AudioClip[] aClips;
    public AudioSource AudioSourceComponent;
    
    string objName;
    

    // Use this for initialization
    void Start () {
        AudioSourceComponent = GetComponent < AudioSource >();
      
        AudioSourceComponent.clip = aClips[0];
        AudioSourceComponent.Play();
       
    }
	
	// Update is called once per frame
	void FixedUpdate() {
		if(Input.touchCount>0 && Input.touches[0].phase==TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if(Physics.Raycast(ray, out Hit))
            {
                objName = Hit.transform.name;
                switch (objName)
                {
                    case "Wolf":
                        AudioSourceComponent.clip = aClips[1];
                        AudioSourceComponent.Play();
                        Invoke("BaseState", 15f);
                        break;
                    default:
                        AudioSourceComponent.clip = aClips[0];
                        AudioSourceComponent.Play();
                        break;

                }
            }
        
        }
	}
    private void BaseState()
    {
        AudioSourceComponent.clip = aClips[0];
        AudioSourceComponent.Play();

        return;     
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour {

    public InteractableObjectController[] collection;

    // Update is called once per frame
    private void Awake()
    { 
        collection = FindObjectsOfType<InteractableObjectController>();
    }
}
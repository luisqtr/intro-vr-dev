using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{

    public GameObject objectToChange;
    public Material newMaterial;
    private Material originalMaterial;
    private bool currentlyOrigMaterial;

    // Start is called before the first frame update
    void Start()
    {
        originalMaterial = objectToChange.GetComponent<Renderer>().materials[0];
        currentlyOrigMaterial = true;
    }

    public void ChangeMaterial()
    {
        if(currentlyOrigMaterial)
        {
            objectToChange.GetComponent<Renderer>().material = newMaterial;
            currentlyOrigMaterial = false;
        }
        else
        {
            objectToChange.GetComponent<Renderer>().material = originalMaterial;
            currentlyOrigMaterial = true;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            ChangeMaterial();
        }
    }

}

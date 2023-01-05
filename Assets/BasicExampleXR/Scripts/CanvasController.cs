using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [Header("Slider to rotate light")]
    public GameObject directionalLightObject;
    private Vector3 initialRotation;

    [Header("Button to change material")]
    public GameObject objectToChangeMaterial;
    public List<Material> materialsList;
    private Material originalMaterial;
    private int currentMaterialIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(directionalLightObject== null)
            initialRotation = directionalLightObject.transform.localEulerAngles;

        if (objectToChangeMaterial != null)
            originalMaterial = objectToChangeMaterial.GetComponent<Renderer>().materials[0];
    }

    void OnDisable()
    {
        if (directionalLightObject == null)
            directionalLightObject.transform.localEulerAngles = initialRotation;

        if (objectToChangeMaterial != null)
            objectToChangeMaterial.GetComponent<Renderer>().material = originalMaterial;
    }

    public void RotateLight(float value)
    {
        if (directionalLightObject == null)
            return;

        directionalLightObject.transform.localEulerAngles = new Vector3(initialRotation.x + 270.0f*value,
                                                                                initialRotation.y, 
                                                                                initialRotation.z);
    }

    public void ChangeMaterial()
    {
        if (objectToChangeMaterial == null)
            return;

        // Check that materials index is within boundaries
        currentMaterialIndex++;
        if(currentMaterialIndex >= materialsList.Count - 1)
            currentMaterialIndex= 0;

        // Change material
        objectToChangeMaterial.GetComponent<Renderer>().material = materialsList[currentMaterialIndex];
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            ChangeMaterial();
        }
    }

}

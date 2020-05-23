using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorPicker : MonoBehaviour
{
    
    public Material materialToAssign;
    public Color colorToChoose;
    private MeshRenderer rend;

    private void Awake()
    {
        materialToAssign = new Material(materialToAssign);
        rend = GetComponent<MeshRenderer>();
        materialToAssign.SetColor("Color_AD890355", colorToChoose * 10);
        materialToAssign.color = colorToChoose;
        rend.material = materialToAssign;
    }
}

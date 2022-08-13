using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public Material Material;

    void Start()
    {
        Material.SetFloat("Vector1_cea281b0dca748f0ad69f411010bac03", 0.5f);
    }
}

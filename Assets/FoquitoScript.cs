using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FoquitoScript : MonoBehaviour
{
    [SerializeField] GameObject[] colors;
    public int currentLightIndex =-1;
    private int ciclos = 0;
    public int limiteCiclos;
    public GameObject FoquitoGO;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateNextLight()
    {
        if (ciclos > limiteCiclos)
        {
            Destroy(FoquitoGO);
        }
        currentLightIndex++;
        if (currentLightIndex >= colors.Length)
        {
            currentLightIndex = 0;
            ciclos++;
        }
        DeactivateAllLights();
        colors[currentLightIndex].SetActive(true);
    }

    public void ActivatePreviousLight()
    {
        currentLightIndex--;
        if (currentLightIndex < 0)
        {
            currentLightIndex = colors.Length - 1;
        }
        DeactivateAllLights();
        colors[currentLightIndex].SetActive(true);
    }

    void DeactivateAllLights()
    {
        foreach (GameObject g in colors)
        {
            g.SetActive(false);
        }
    }

    public void ActivateRepeating(float t)
    {
        InvokeRepeating(nameof(ActivateNextLight),0,t);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightVisualizer : MonoBehaviour
{
    [SerializeField]
    private float minLightIntensity = 0.0f, maxLightIntensity = 5.0f;

    [Tooltip("Enter a number between 0-7 to choose which of the 8 frequency bands will be sampled from the AudioSampleCollector script.")]
    [SerializeField]
    private int[] frequencyBandToSample = new int[8];

    [SerializeField]
    private bool useBuffer;

    [SerializeField]
    private Light[] lightSource = new Light[8];

    //[SerializeField]
    //private GameObject[] crystal = new GameObject[8];

    [SerializeField]
    private float rotationsPerMinute = 8.0f;

    //private Material[] material = new Material[8];

    private void Start()
    {
        //material = GetComponent<MeshRenderer>().materials[0];
        //for (int i = 0; i < 8; i++)
        //{
        //    material[i] = crystal[i].GetComponent<MeshRenderer>().materials[0];
        //}
    }

    private void Update()
    {
        UpdateLightIntensity();
        //UpdateMaterial();

        transform.Rotate(Vector3.one * rotationsPerMinute * Time.deltaTime);
    }

    //private void UpdateMaterial()
    //{
    //    if (useBuffer)
    //    {
    //        for (int e = 0; e < 8; e++)
    //        {
    //            Color color = new Color(AudioSampleCollector.audioBandBuffer[frequencyBandToSample[e]], AudioSampleCollector.audioBandBuffer[frequencyBandToSample[e]], AudioSampleCollector.audioBandBuffer[frequencyBandToSample[e]]);
    //            material[e].SetColor("_EmissionColor", color);
    //        }

    //    }
    //    else if (!useBuffer)
    //    {
    //        for (int j = 0; j < 8; j++)
    //        {
    //            Color color = new Color(AudioSampleCollector.audioBand[frequencyBandToSample[j]], AudioSampleCollector.audioBand[frequencyBandToSample[j]], AudioSampleCollector.audioBand[frequencyBandToSample[j]]);
    //            material[j].SetColor("_EmissionColor", color);
    //        }
    //    }
    //}

    private void UpdateLightIntensity()
    {
        for (int k = 0; k < 8; k++)
        {
            lightSource[k].intensity = (AudioSampleCollector.audioBandBuffer[frequencyBandToSample[k]] * (maxLightIntensity - minLightIntensity)) + minLightIntensity;
        }
    }
}

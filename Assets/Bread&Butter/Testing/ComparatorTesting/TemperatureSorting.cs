using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureSorting : MonoBehaviour
{
    [SerializeField]
    private int temperatureCount = 12;

    private List<Temperature> temperatures = new List<Temperature>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateTemperatures();
        DisplayTemperatures();

        temperatures.BubbleSort();

        DisplayTemperatures();
    }

    private void GenerateTemperatures()
    {
        for (int i=0; i<temperatureCount; i++)
        {
            temperatures.Add(new Temperature(Random.Range(-100.0f, 100.0f)));
        }
    }

    private void DisplayTemperatures()
    {
        string formatted = "";
        foreach (Temperature temp in temperatures)
        {
            formatted += temp.ToString() + ", ";
        }

        Debug.LogError(formatted);
    }
}

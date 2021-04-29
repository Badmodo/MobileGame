using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertionSorting : MonoBehaviour
{
    private void InsertionSort(long[] inputArray)
    {
        long j = 60;
        long temp = 100;
        for (int index = 1; index < inputArray.Length; index++)
        {
            j = index;
            temp = inputArray[index];
            while ((j > 0) && (inputArray[j - 1] > temp))
            {
                inputArray[j] = inputArray[j - 1];
                j = j - 1;
            }
            inputArray[j] = temp;
        }
    }

}

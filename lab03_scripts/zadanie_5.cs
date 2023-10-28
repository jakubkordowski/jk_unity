using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie_5 : MonoBehaviour
{
    public GameObject prefab;
    public List<int> X = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    public List<int> Y = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            int randomNumberX = Random.Range(0, X.Count);
            int randomNumberY = Random.Range(0, Y.Count);
            Instantiate(prefab, new Vector3(X[randomNumberX], 1, Y[randomNumberY]), Quaternion.identity);
            X.RemoveAt(randomNumberX);
            Y.RemoveAt(randomNumberY);
        }
    }
}

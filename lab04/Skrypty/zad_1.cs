using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class zad_1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;

    public int liczbaDoGenerowania;
    public Material[] materialList; 
    void Start()
    {
        Collider col = GetComponent<Collider>();
        float minX = col.bounds.min.x;
        float minZ = col.bounds.min.z;
        float maxX = col.bounds.max.x;
        float maxZ = col.bounds.max.z;
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range((int)minX, (int)maxX).OrderBy(x => Guid.NewGuid()).Take(liczbaDoGenerowania));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)minZ, (int)maxZ).OrderBy(x => Guid.NewGuid()).Take(liczbaDoGenerowania));

        for (int i = 0; i < liczbaDoGenerowania; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");

        foreach (Vector3 pos in positions)
        {
            int index = UnityEngine.Random.Range(0, materialList.Length);
            this.block.GetComponent<MeshRenderer>().material = materialList[index];
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}

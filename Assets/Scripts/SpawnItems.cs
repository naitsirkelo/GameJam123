using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{

    public GameObject item;


    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> positions = new List<Vector3>();

        //Add spawn positions for collectibles
        positions.Add(new Vector3(16.98f, 1.16f, 164.55f));
        positions.Add(new Vector3(3.02f, 4.75f, -4.04f));
        positions.Add(new Vector3(-304.34f, 0.901f, 143.013f));
        positions.Add(new Vector3(-340.19f, 2.111f, 100.929f));
        positions.Add(new Vector3(-331.61f, 3.158f, 32.518f));
        positions.Add(new Vector3(-285.99f, 1.271f, 86.053f));
        positions.Add(new Vector3(-330.62f, 0.294f, -25.538f));
        positions.Add(new Vector3(-267.49f, 3.123f, -35.350f));
        positions.Add(new Vector3(-154.86f, 22.95f, 225.93f));
        positions.Add(new Vector3(-28.628f, 52.529f, -124.84f));
        positions.Add(new Vector3(-46.732f, 2.51f, -206.03f));
        positions.Add(new Vector3(-54.97f, 3.255f, -198.06f));
        positions.Add(new Vector3(-564.9f, 4.52f, 42.014f));
        positions.Add(new Vector3(-122.427f, 5.79f, -220.051f));
        positions.Add(new Vector3(-210.028f, 6.8044f, -157.0f));
        positions.Add(new Vector3(-307.228f, 4.187f, -21.959f));
        positions.Add(new Vector3(-121.445f, 45.051f, 467.867f));
        positions.Add(new Vector3(-139.98f, 49.643f, 455.031f));
        positions.Add(new Vector3(100.343f, 107.964f, -8.247f));
        positions.Add(new Vector3(-78.753f, 4.273f, -30.758f));
        positions.Add(new Vector3(-90.146f, 0.27f, -15.695f));
        positions.Add(new Vector3(-275.033f, 1.457f, -164.965f));
        positions.Add(new Vector3(-334.876f, 0.35f, -83.729f));
        positions.Add(new Vector3(-297.2498f, 2.49f, 415.475f));




        int x = 0;
        for(int i = 0; i < positions.Count; i++) {
            Instantiate(item, positions[i], Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

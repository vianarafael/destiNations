using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

public class Arc : MonoBehaviour
{
    public VectorLine arc;
    public GameObject departure;
    public GameObject destination;

    // Start is called before the first frame update
    void Start()
    {
        departure = GameObject.FindGameObjectWithTag("JP");
        destination = GameObject.FindGameObjectWithTag("CA");

        float dist = Vector3.Distance(departure.transform.position, destination.transform.position);
        Vector3 midpoint = (departure.transform.position + destination.transform.position) * 0.5f;
        var linepoints = new List<Vector3>(21);

        VectorLine arc = new VectorLine("Arc", linepoints, 4.0f, LineType.Continuous);
        arc.MakeArc(midpoint, dist / 2, dist / 2, 0.0f, 360.0f, 20);
        arc.Draw3D();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

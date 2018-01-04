using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        Camera m_Camera = Camera.main;
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }

    private void OnMouseDown()
    {
        
        Vector3 startPos = Camera.main.transform.position;
        Vector3 endPos = transform.position;
        float length = Vector3.Distance(startPos, endPos);
        Vector3 trackPos = startPos;
        while (length >= .5f)
        {
            Camera.main.transform.position = Vector3.Lerp(
               Camera.main.transform.position,
               endPos,
               Time.deltaTime * 1.0f
            );
            length -= Vector3.Distance(trackPos, Camera.main.transform.position);
            trackPos = Camera.main.transform.position;
        }
    }
}
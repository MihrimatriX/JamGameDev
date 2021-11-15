using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public Transform CamPos;
    public Transform KarakterPos;

    Vector3 CamPosV;

    void Update()
    {
        CamPosV = CamPos.transform.position;
        CamPosV.x = KarakterPos.transform.position.x;
        transform.position = Vector3.Lerp(transform.position, CamPosV, Time.deltaTime * 4f);
    }
}

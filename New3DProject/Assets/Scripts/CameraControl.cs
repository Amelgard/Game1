using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector3 mousePos;
    private GameObject Camera;
    private void Awake()
    {
        FindCamera();
    }
    private void FindCamera()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    public void LookAtTarget(Vector3 cameraTargetPosition)
    {
        Camera.transform.LookAt(cameraTargetPosition);
    }
    public void CameraMover(GameObject cameraTarget, Vector3 cameraOffset)
    {
        float targetSize = cameraTarget.transform.lossyScale.x;
        Vector3 newCameraCenter = cameraTarget.transform.position + (cameraOffset * targetSize);
        Camera.transform.position = newCameraCenter;
    }
    
    private void ObjectTransparency()
    {

    }
}

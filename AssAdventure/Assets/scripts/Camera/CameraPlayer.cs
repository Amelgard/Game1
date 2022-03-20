using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    private GameObject _target;
    public Vector3 cameraOffset;

    void Update()
    {
        TargetFolow();
    }

    private void TargetFolow()
    {  
        if(_target != null)
            Camera.main.transform.position = _target.transform.position + cameraOffset;
    }

    public void SetTarget(GameObject target){ _target = target; }

}

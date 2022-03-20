using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    private GameObject player;
    public float Ypos;
    public float Xpos;
    public float Zpos;
    public float CamRot;
    private float Yrot;
    private float Zrot;
    void Update()
    {
        PlayerCam();
    }
    public void PlayerCam()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (player != null)
        {
            Quaternion camRot = new Quaternion(CamRot, Yrot,Zrot,100f);
            Vector3 playerpos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            Camera.main.transform.position = new Vector3(playerpos.x +Xpos, playerpos.y+ Ypos, playerpos.z+ Zpos);
            Camera.main.transform.rotation = new Quaternion(camRot.x,0,0,100f);
        }
    }
}

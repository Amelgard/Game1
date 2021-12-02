using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    PlayerControl playerControl;
    ObjectStats playerStats;
    StatManipulate statManipulate;
    CameraControl cameraControl;
    private GameObject player;
    public Vector3 cameraOffset;
    public GameObject test;
    Inventory inventory;
    private void Awake()
    {
        IncludeScripts();
        player = playerControl.FindPlayer();
        playerStats = player.GetComponent("ObjectStats") as ObjectStats;
        playerStats.stamina = playerStats.maxStamina;
        playerStats.helth = playerStats.maxHelth;
        playerStats.mana = playerStats.maxMana;
        inventory = new Inventory();
    }
    private void Update()
    {
        StatsRecavery();
        playerControl.ObjectMover(player, playerStats.speed);
        cameraControl.CameraMover(player, cameraOffset);
        cameraControl.LookAtTarget(player.transform.position);
    }

    private void IncludeScripts()
    {
        playerControl = gameObject.GetComponent("PlayerControl") as PlayerControl;
        statManipulate = gameObject.GetComponent("StatManipulate") as StatManipulate;
        cameraControl = gameObject.GetComponent("CameraControl") as CameraControl;
    }
    private void StatsRecavery()
    {
        playerStats.stamina = statManipulate.StaminaRecavery(playerStats.stamina, playerStats.maxStamina, 2);
        playerStats.mana = statManipulate.ManaRecavery(playerStats.mana, playerStats.maxMana, 2);
        playerStats.helth = statManipulate.HelthRecavery(playerStats.helth, playerStats.maxHelth, 2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    PlayerControl playerControl;
    PlayerStats playerStats;
    StatManipulate statManipulate;
    CameraControl cameraControl;
    private GameObject player;

    private void Awake()
    {
        IncludeScripts();
        player = playerControl.FindPlayer();
        playerStats.stamina = playerStats.maxStamina;
        playerStats.helth = playerStats.maxHelth;
        playerStats.mana = playerStats.maxMana;
    }
    private void Update()
    {
        StatsRecavery();
        playerControl.ObjectMover(player, playerStats.speed);
        cameraControl.CameraMover(player, playerStats.speed - 1, 3.5f, 1.5f);
    }

    private void IncludeScripts()
    {
        playerControl = gameObject.GetComponent("PlayerControl") as PlayerControl;
        statManipulate = gameObject.GetComponent("StatManipulate") as StatManipulate;
        playerStats = gameObject.GetComponent("PlayerStats") as PlayerStats;
        cameraControl = gameObject.GetComponent("CameraControl") as CameraControl;
    }
    private void StatsRecavery()
    {
        playerStats.stamina = statManipulate.StaminaRecavery(playerStats.stamina, playerStats.maxStamina, 2);
        playerStats.mana = statManipulate.ManaRecavery(playerStats.mana, playerStats.maxMana, 2);
        playerStats.helth = statManipulate.HelthRecavery(playerStats.helth, playerStats.maxHelth, 2);
    }
}
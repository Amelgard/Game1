using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAggregator : MonoBehaviour
{
    PlayerControl playerControl;
    public GameObject player;

    private void Start()
    {
        playerControl = gameObject.GetComponent("PlayerControl") as PlayerControl;
        player = playerControl.FindPlayer();
    }
    private void Update()
    {
        playerControl.ObjectController(player, 2);
    }
}

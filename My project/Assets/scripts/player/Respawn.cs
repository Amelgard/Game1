using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Respawn : MonoBehaviour
{

    public bool scan = true;

    public GameObject respawnMenu;
    public GameObject PlayerStatUI;
    public GameObject RespawnButton;
    public GameObject PlayerPrefab;
    private GameObject SpawnPlayer;

    public void Awake()
    {
    }
    void Update()
    {
        Scan();
    }

    public void Scan()
    {
        
        if (GameObject.FindGameObjectWithTag("Player") == null && scan==true)
        {
            Debug.Log("Игрок умер");
            PlayerStatUI.SetActive(false);
            respawnMenu.SetActive(true);
            scan = false;
        }
        if (scan==false)
        {
            RespawnButton.GetComponent<Button>().onClick.AddListener(RespawnPlayer);
            
        }
    }
    public void RespawnPlayer()
    {
        if (scan==false) {
            Vector3 resp = new Vector3(0, 2, -3);
            SpawnPlayer = Instantiate(PlayerPrefab, resp, Quaternion.identity) as GameObject;
            PlayerStatUI.SetActive(true);
            respawnMenu.SetActive(false);
            scan = true;
        }
    }
}

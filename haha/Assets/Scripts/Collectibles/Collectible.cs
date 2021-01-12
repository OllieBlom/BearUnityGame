using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public TMP_Text scoretxt;
    public Transform CollectibleModel;
    public GameObject particleEffect;

    //private int amountCollected = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CollectibleModel.Rotate(new Vector3(0,0,1), Space.Self);
        
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.GetComponent<ThirdPersonController>() != null)
        {
            Debug.Log("Player Has Collected!");
            Globals.fishAmount += 1;
            scoretxt.text = Globals.fishAmount + "/10";
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

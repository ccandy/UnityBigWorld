using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLoader : MonoBehaviour
{


    public Transform PlayerTransformer;
    public float CheckTimer = 1;
    void Start()
    {
        StartCoroutine(PlayerPositionChecker());
    }

    IEnumerator PlayerPositionChecker()
    {
        while (true)
        {
            if(PlayerTransformer != null)
            {
                Debug.Log("Player pos " + PlayerTransformer.position);
            }
            else
            {
                Debug.LogError("Player is null");
            }
            yield return new WaitForSeconds(CheckTimer);
        }
        

    } 
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLoader : MonoBehaviour
{
    public Transform PlayerTransformer;
    public BWLand Land;
    public float CheckTimer = 1;

    private float _currentMove;

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
                CheckPositionTiles();
            }
            else
            {
                Debug.LogError("Player is null");
            }
            yield return new WaitForSeconds(CheckTimer);
        }
    } 
    

    private void CheckPositionTiles()
    {
        Vector3 pos = PlayerTransformer.position;
        if (Land.CheckPos(pos))
        {

        }
    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWLand : MonoBehaviour
{

    public int Width, Height;
    public int CellSize;

    private int _xPos, _yPos;

    

    private int _xCurrentPos, _yCurrentPos, _zCurrentPos;
    public int XCurrentPos
    {
        get
        {
            return _xCurrentPos;
        }
    }

    public int YCurrentPos
    {
        get
        {
            return _yCurrentPos;
        }
    }

    public int ZCurrentPos
    {
        get
        {
            return _zCurrentPos;
        }
    }
    // [SerializeField]
    private GameObject[,] _lands;

    // Start is called before the first frame update
    private void Awake()
    {
        _xCurrentPos = _yCurrentPos = _zCurrentPos = 0;

        LoadLands();
    }

    private void LoadLands()
    {
        _lands = new GameObject[Width,Height];
        Transform[] trans = gameObject.GetComponentsInChildren<Transform>();
        int i = 1;
        for (int x = 0; x < Height; x++)
        {
            for (int y = 0; y < Width; y++)
            {
                Transform t = trans[i++];
                _lands[x, y] = t.gameObject;
            }
        }
    }

    public GameObject GetLand(int x, int y)
    {
        if(_lands == null)
        {
            return null;
        }
        return _lands[x, y];
    }


    public bool CheckPos(Vector3 pos)
    {

        int xPos = (int)Mathf.Floor(pos.x / CellSize);
        int zPos = (int)Mathf.Floor(pos.z / CellSize);

        if(xPos != _xCurrentPos || zPos != _zCurrentPos)
        {

            _xCurrentPos = xPos;
            _zCurrentPos = zPos;
            return true;
        }
        return false;
    }

}

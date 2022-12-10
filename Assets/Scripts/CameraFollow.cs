using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //CONSTANTS
    private const string PLAYER_TAG = "Player";

    private Transform player;
    private Vector3 tempPos;


    [SerializeField]
    public float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (!player) return;
        tempPos = transform.position;
        tempPos.x = player.position.x;
        if (tempPos.x < minX)
            tempPos.x = minX;
        if (tempPos.x > maxX)
            tempPos.x = maxX;
        transform.position = tempPos;
    }
} //class 

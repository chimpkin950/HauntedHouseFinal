using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MapFollowPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    private Image mapPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // FIXME VECTOR3 PARAM
        mapPosition.rectTransform.localPosition = new Vector3(0f,0f,0f);
    }
}

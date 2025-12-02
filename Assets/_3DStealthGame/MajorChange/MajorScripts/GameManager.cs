using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Minimap;

public class GameManager : MonoBehaviour
{
    //Did not fix object reference error
    //private MinimapWindow mapInstance;

    private void Start()
    {
        // Did not fix object reference error
        //mapInstance = GameObject.Find("MinimapWindow").GetComponent<MinimapWindow>();
    }

    // Update is called once per frame
    void Update()
    {
        // Open minimap when + pressed
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            Minimap.MinimapWindow.Show();
            Debug.Log("Minimap displayed!");
        }

        // Deactivate minimap when - pressed
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            Minimap.MinimapWindow.Hide();
            Debug.Log("Minimap hidden.");
        }
    }
}

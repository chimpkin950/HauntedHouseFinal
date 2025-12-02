using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Put in namespace to reference under other libraries
namespace Minimap {
    public class MinimapWindow : MonoBehaviour
    {
        // Variable instance of the UI Minimap element
        private static MinimapWindow mapInstance;

        // Initializes the instance
        private void Start()
        {
            mapInstance = GameObject.Find("MinimapWindow").GetComponent<MinimapWindow>();
        }

        // Method reveals the minimap when called
        public static void Show()
        {
            mapInstance.gameObject.SetActive(true);
        }

        // Hide minimap when called
        public static void Hide()
        {
            mapInstance.gameObject.SetActive(false);
        } 
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectIfOutOfBounds : MonoBehaviour {

    CameraObjectFollow cameraObjecFollow;
    public GameObject cameraOrPivot;

    void Start()
    {
        cameraObjecFollow = cameraOrPivot.GetComponent<CameraObjectFollow>();
        
    }

    private void Update()
    {
        CheckIfOffscreen();
    }

    void CheckIfOffscreen()
    {
        // Die by being off screen
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.x > Screen.width || screenPosition.x < 0)
        {
            foreach(GameObject obj in cameraObjecFollow.players.ToArray())
            if(transform.position == obj.transform.position)
            {
                    cameraObjecFollow.players.Remove(obj);
                    Destroy(gameObject);
            }

        }
    }
}

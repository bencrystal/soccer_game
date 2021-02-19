using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollower : MonoBehaviour
{

    //public Transform player;
    public float cameraDistance = 70.0f;

    private void Awake()
    {
        {
            GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
        }
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (Services.Players != null && Services.Players.Length > 0)
        {
            transform.position = new Vector3(Services.Players[0].position.x, Services.Players[0].position.y, -1);
        }
    }
}

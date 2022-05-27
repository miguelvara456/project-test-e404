using System;
using UnityEngine;
using Events;
using Objects;

public class PlayerContoller : MonoBehaviour
{
    
    [Header("Events")]
    [SerializeField] private CustomEvent OnUpdateGame;
    private LayerMask layerRaycast;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        OnUpdateGame.OnEvent.AddListener(Inputs);
        layerRaycast = LayerMask.GetMask("Default");
    }

    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateRaycast();
        }
    }

    private void CreateRaycast()
    {
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(cameraRay, out hit, 250f, layerRaycast))
            hit.collider.GetComponent<BaseObject>().OnClickObject();
        
    }
}

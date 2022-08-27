using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMousePlane : MonoBehaviour
{
    [SerializeField] PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnMouseDown()
    {
        if (player != null)
        {

            Debug.Log(Input.mousePosition);
            player.Cursor3D.transform.position = GetPosition(Input.mousePosition);
        }
    }

    private Vector3 GetPosition(Vector3 mousePosition)
    {
        RaycastHit hit;
        Ray rayCamera = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(rayCamera, out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}

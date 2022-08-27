using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAgent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject cursor3D;

    private NavMeshAgent playerAgent;

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CursorUpdate();
        playerAgent.destination = cursor3D.transform.position;
    }

    void CursorUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cursor3D.transform.position = GetPosition(Input.mousePosition);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lifes"))
        {
            GameManager.addScore();
            Destroy(other.gameObject);
        }
    }
}

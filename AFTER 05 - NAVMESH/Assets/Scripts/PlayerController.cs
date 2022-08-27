using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject cursor3D;
    public GameObject Cursor3D { get => cursor3D; set => cursor3D = value; }

    [SerializeField] float speed = 5f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //   PUNTO A (PLAYER) -> PUNTO B(EL CURSOR3D/ENEMIGO/UNA META) = (B-A) = DIRECCIONA DE DESPLAZAMIENTO
        Vector3 directionToMove = cursor3D.transform.position - transform.position;
        if (directionToMove.magnitude > 1f)
        {
            transform.LookAt(cursor3D.transform.position);  
            transform.position += speed * directionToMove.normalized * Time.deltaTime;
        }

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

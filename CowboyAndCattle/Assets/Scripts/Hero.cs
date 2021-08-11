using System;
using UnityEngine;
using UnityEngine.AI;

public class Hero : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject[] target;
    [SerializeField] private int targetNum = 0;
    [SerializeField] private GameObject pfbCube;

    private void Awake()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayCast, out hit))
            {
                Instantiate(pfbCube, new Vector3(hit.point.x,hit.point.y+1,hit.point.z), Quaternion.identity);
            }
        }
    }

    private void FixedUpdate()
    {
        if (targetNum < target.Length)
        {
            navMeshAgent.destination = target[targetNum].transform.position;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            Destroy(other.gameObject);
            targetNum++;
        }
    }
}

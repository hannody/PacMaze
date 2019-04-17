using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiTranWall : MonoBehaviour
{
    Transform target;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Ray ray = GetComponent<Camera>().ScreenPointToRay(target.position);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            print(hit.transform.name);
        }
    }
}

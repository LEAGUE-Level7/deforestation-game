using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{

    [SerializeField] GameObject ParalaxImg;
    [SerializeField] int amount;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        ParalaxImg.transform.position = new Vector3((mousePos.x/ amount) + 600, (mousePos.y/ amount) + 300, 0);
    }
}

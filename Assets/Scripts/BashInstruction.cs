using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BashInstruction : MonoBehaviour
{
    [SerializeField] private GameObject Arrows;
    [SerializeField] private GameObject Letters;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Arrows.SetActive(true);
            Letters.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.L))
        {
            Arrows.SetActive(false);
            Letters.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class WorkReset : MonoBehaviour
{
    public GameObject iconOne;
    public GameObject iconTwo;
    public GameObject iconThree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WorkClick.filesClosed % 3 == 0)
        {
            
            iconOne.SetActive(true);
            iconTwo.SetActive(true);
            iconThree.SetActive(true);
        }
    }
}

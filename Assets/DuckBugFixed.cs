using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBugFixed : MonoBehaviour
{
     
    void Update()
    {
        if(this.transform.rotation.y < 0)
        {
            this.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}

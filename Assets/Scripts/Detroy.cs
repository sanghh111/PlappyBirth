using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DetroyPipe", 10f);
    }

    void DetroyPipe()
    {
        Destroy(gameObject);
    }
}

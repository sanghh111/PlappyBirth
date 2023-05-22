using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject pipePrefab;
    // Instantiate
    private float countdown;
    public float timeDuration;
    public bool enabledGeneratePipe;
    private void Awake() {
        countdown = 1f;
        enabledGeneratePipe = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(enabledGeneratePipe == true){
            countdown -= Time.deltaTime;// mỗi frame countdown -= 1/fps
            //30 FPS: mỗi frame countdown giarm đi 1/30s, một giây (30 frames) thì countdown giảm đúng đi 1
            if(countdown <= 0 ){
                //sinh ra ống
                Instantiate(pipePrefab, new Vector3(10,Random.Range(-1.2f,2.1f)), Quaternion.identity);
                countdown = timeDuration;
            }
        }
    }
}

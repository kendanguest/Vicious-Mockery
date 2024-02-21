using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class DustKickingParticleControl : MonoBehaviour
{
    public KeyCode Key;
    public GameObject prefab;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            createdust();
        }
    }

    void createdust()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        prefab.transform.position = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        
        prefab.GetComponent<ParticleSystem>().Play();
        Instantiate(prefab);

        //clone.transform.localPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        

        
    }
}

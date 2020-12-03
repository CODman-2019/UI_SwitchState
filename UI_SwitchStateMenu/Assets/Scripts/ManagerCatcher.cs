using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCatcher : MonoBehaviour
{
    public GameObject GameManager;

    // Start is called before the first frame update
    void Awake()
    {
        
        if(GameObject.FindGameObjectsWithTag("GameManager").Length == 0)Instantiate(GameManager);

        Destroy(this);

    }




}

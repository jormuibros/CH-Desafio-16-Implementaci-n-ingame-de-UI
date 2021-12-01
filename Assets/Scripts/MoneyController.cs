using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{

    [SerializeField] GameManager.typeMoney typemoney; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameManager.typeMoney GetTypeMoney()
    {
        return typemoney; 
    }
}


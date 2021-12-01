using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int  Score;
    public enum typeMoney {Gold, Silver, Bronce};
    public enum typesFood { Apple , Watermelon, Peach };
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Score =0;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addScore()
    {
        instance.Score +=1;
    }
    public int getScore()
    {
     return instance.Score;
    }
}

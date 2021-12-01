using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LandingController : MonoBehaviour
{
    [SerializeField] private InputField InputUsername;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChangeInputUsername()
    {
        Debug.Log("CHANGE");
        Debug.Log(InputUsername.text);
    }

    public void OnEndEditInputUsername()
    {
        Debug.Log("END EDIT");
        ProfileManager.instance.SetPlayerName(InputUsername.text);
        Debug.Log("SAVED USERNAME"+ ProfileManager.instance.GetPlayerName());
    }

    public void OnClickPlay()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
}

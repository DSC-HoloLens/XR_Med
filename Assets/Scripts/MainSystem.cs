using UnityEngine;
using UnityEngine.Networking;
using System.Collections; 

using UnityEngine.UI;
using TMPro;
public class MainSystem : MonoBehaviour
{

    // Start is called once befo
    public Transform reference;

    public GameObject popup;

    private GameObject current_popup; 
    
    public string DebugText; 


    public void buttonClicked()
    {
       
    }

    void Start() {
        if(current_popup != null)
        {
            Destroy(current_popup);
        }
        current_popup = Instantiate(popup, reference.position, reference.rotation);
        current_popup.GetComponentInChildren<TextMeshProUGUI>().text = DebugText;
        StartCoroutine(GetRequest("http://172.27.29.217:8000/medical-term"));

    }

    IEnumerator GetRequest(string uri) {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)){
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if(webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.downloadHandler.text);
                //Debug.LogError("Error", webRequest);
            }
            else{
                Debug.Log("Error");
            }
        }
    }   
}

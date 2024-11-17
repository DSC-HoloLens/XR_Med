using UnityEngine;
using UnityEngine.Networking;
using System.Collections; 

using UnityEngine.UI;
using TMPro;
public class MainSystem : MonoBehaviour
{

    // Start is called once befo

    public string destination;

    public Transform reference;

    public GameObject popup;

    private GameObject current_popup; 
    
    public string DebugText; 


    public void buttonClicked()
    {
        if(current_popup != null)
        {
            Destroy(current_popup);
        }
        current_popup = Instantiate(popup, reference.position, reference.rotation);
        StartCoroutine(GetRequest($"{destination}/test", current_popup));

    }

    private IEnumerator GetRequest(string URL, GameObject created_popup)
    {
        using (UnityWebRequest res = UnityWebRequest.Get(URL))
        {
            yield return res.SendWebRequest();

            if(res.result == UnityWebRequest.Result.Success)
            {
                string response_text = res.downloadHandler.text; 
                created_popup.GetComponentInChildren<TextMeshProUGUI>().text = response_text;
            }
            else 
            {
                created_popup.GetComponentInChildren<TextMeshProUGUI>().text = "error reading message";
            }
        }
    }
}

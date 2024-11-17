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
        if(current_popup != null)
        {
            Destroy(current_popup);
        }
        current_popup = Instantiate(popup, reference.position, reference.rotation);
        current_popup.GetComponentInChildren<TextMeshProUGUI>().text = DebugText;
    }
}

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

    private string[] popupArray;

    
    public string DebugText; 

    public void Start()
    {
            if(current_popup != null)
        {
            Destroy(current_popup);
        }

        int maxCharactersPerPage = 200;
        int textLength = DebugText.Length;
        int numPages = Mathf.CeilToInt((float)textLength / maxCharactersPerPage); 
        popupArray = new string[numPages]; 

        for (int i = 0; i < numPages; i++)
        {
            // substring of 200 characters
            string pageText = DebugText.Substring(i * maxCharactersPerPage, Mathf.Min(maxCharactersPerPage, textLength - i * maxCharactersPerPage));

            popupArray[i] = pageText;
        }

        // create a new popup for each page
        current_popup = Instantiate(popup, reference.position, reference.rotation);
        TextMeshProUGUI textComponent = current_popup.GetComponentInChildren<TextMeshProUGUI>();
        textComponent.text = popupArray[0];
        // automatically set the size of the text
        textComponent.enableAutoSizing = true;
    }

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

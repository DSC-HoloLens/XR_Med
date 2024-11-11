using UnityEngine;
using UnityEngine.Networking;
using System.Collections; 
public class MainSystem : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject debug_swag; 


    public void buttonClicked()
    {
        StartCoroutine(GetRequest("http://172.27.28.151:3000/test")); 

    }

    private IEnumerator GetRequest(string URL)
    {
        using (UnityWebRequest res = UnityWebRequest.Get(URL))
        {
            yield return res.SendWebRequest();

            if(res.result == UnityWebRequest.Result.Success)
            {
                this.debug_swag.transform.position += new Vector3(0.0f, 0.5f, 0.0f);
            }
            else 
            {
                this.debug_swag.transform.position -= new Vector3(0.0f, -0.5f, 0.0f);
            }
        }
    }
}

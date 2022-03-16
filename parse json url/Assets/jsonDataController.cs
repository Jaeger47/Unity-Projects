using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using UnityEngine.UI;

public class jsonDataController : MonoBehaviour
{
    private string url = "https://raw.githubusercontent.com/Jaeger47/T192_DACER/main/student_data.json";

 
    public Text myText;

    public void getRequest() {
        StartCoroutine(makeRequest());
    }

    IEnumerator makeRequest() {

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            var student_data_json = JsonConvert.DeserializeObject<jsonDataClass>(request.downloadHandler.text);
            //string myString_Data = student_data_json.students;

            foreach(Student x in student_data_json.students){
                myText.text = myText.text + "\n" +
                "name: " + x.name + "\n" + 
                "Age: " + x.age + "\n" + 
                "Email: " + x.email + "\n" + 
                "Enrollment Status: " + x.isEnrolled + 
                "\n\n";
                
            }
            
        }
    }

    
}

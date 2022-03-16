using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class jsonDataController : MonoBehaviour
{
    private string pokemonName;
    private string url;
    private string image_url;
    private Texture myTexture;

    public InputField myInput;
    public Text myText;
    public RawImage myPhoto;
    public GameObject myPhoto_GameObject;
    


    public void getPokemonData(){
        StartCoroutine(makeRequest());
        StartCoroutine(makeRequestImage());
    }


    IEnumerator makeRequest(){
        pokemonName = myInput.text;
        url = "https://pokeapi.co/api/v2/pokemon/"+pokemonName;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success){
            Debug.Log(request.error);
        }else{

            var pokemon_data_json = JsonConvert.DeserializeObject<jsonDataClass>(request.downloadHandler.text);
            myText.text = pokemon_data_json.name;
            image_url = pokemon_data_json.sprites.front_default;
        }
    }

    IEnumerator makeRequestImage(){

        yield return new WaitForSeconds(1);
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(image_url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success){
            Debug.Log(request.error);
        }else{

            myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            myPhoto.texture = myTexture;
            myPhoto_GameObject.SetActive(true);

        }
    }

  
}

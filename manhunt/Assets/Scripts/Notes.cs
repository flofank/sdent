using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class Notes : MonoBehaviour
{
    public static string text = "";

    // Use this for initialization
    void Start()
    {
        transform.FindChild("text").gameObject.SetActive(true);
        transform.FindChild("text").gameObject.GetComponent<Text>().text = text;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

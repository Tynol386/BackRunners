using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits_script : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Order());
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }

    IEnumerator Order()
    {
        yield return new WaitForSeconds(20.0f);
        SceneManager.LoadScene("Main_Menu");
    }
}

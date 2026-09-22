using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Order());
    }
    IEnumerator Order()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("Main_Menu");
    }
}

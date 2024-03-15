using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timmer : MonoBehaviour
{
    [SerializeField] float time = 10f;
    [SerializeField] TMP_Text timer;
    [SerializeField] int sceneId;
    int t =0;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        time -= Time.deltaTime;
        t = (int)time;
        timer.text = t.ToString();

        if(time <= 0)
        {
            SceneManager.LoadScene(sceneId);
        }
    }


} 

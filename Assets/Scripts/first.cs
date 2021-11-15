using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class first : MonoBehaviour
{
	public void LoadScene(string tag)
    {
        SceneManager.LoadScene("SampleScene");
    }
}

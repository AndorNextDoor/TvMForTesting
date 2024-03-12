using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int levelID;


    private void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = levelID.ToString();
    }

    public void LoadScene()
    {
        AsyncLoader.instance.LoadLevel(levelID);
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeCollector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI remainCubeText;
    int remainingCubes = 5;
    [SerializeField] GameObject WinPanel;

    private void Update()
    {
        if(remainingCubes <= 0)
        {
            WinPanel.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            remainingCubes--;
            Destroy(collision.gameObject);
            remainCubeText.text = "Cubes Remain : " +  remainingCubes.ToString();
        }
    }
}
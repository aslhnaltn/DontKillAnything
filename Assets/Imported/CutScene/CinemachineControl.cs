using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinemachineControl : MonoBehaviour
{
    public Image panel;

    private void Start()
    {
        panel.gameObject.SetActive(false);
    }

    public void ShowPanel()
    {
        panel.gameObject.SetActive(true);
    }
}

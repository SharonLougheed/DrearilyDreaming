using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMenuManager : MonoBehaviour {

    public GameObject currentPanel;
    public GameObject destinationPanel;
    
    public void ActivateChangePanels() {
        currentPanel.SetActive(!currentPanel.activeInHierarchy);
        destinationPanel.SetActive(!destinationPanel.activeInHierarchy);
    }
}

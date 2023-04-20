using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowToPly : MonoBehaviour
{
    [SerializeField] private GameObject tutorial = null;
    [SerializeField] public Button yourButton;
    [SerializeField] public Button closeButton;

    void Start(){
        Button btn = yourButton.GetComponent<Button>();
        Button btn2 = closeButton.GetComponent<Button>();
        btn2.onClick.AddListener(Done);
		btn.onClick.AddListener(Play);
    }
    public void Play(){
        tutorial.SetActive(true);
    }
    public void Done(){
        tutorial.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class timer : MonoBehaviour
{   [SerializeField]private float count=0;
    [SerializeField] private float endtime = 120;
    private TextMeshProUGUI textMeshProUI;
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUI = GetComponent<TextMeshProUGUI>();

        count=0;
    }

    // Update is called once per frame
    void Update()
    {
        count+=Time.deltaTime;
        textMeshProUI.text = string.Format("{0:N2}", count);
        if (count>=endtime){

            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
        }

    }
}

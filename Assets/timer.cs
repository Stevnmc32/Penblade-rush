using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class timer : MonoBehaviour
{
    public float time = 60;
    [SerializeField]
    private TMP_Text _timer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(time);
        _timer.text = ((int)time).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        _timer.text = ((int)time).ToString();
    }
}

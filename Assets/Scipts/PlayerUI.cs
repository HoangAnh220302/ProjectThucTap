using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public TextMeshProUGUI promtText; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateText(string promtMessage)
    {
        promtText.text = promtMessage;
    }
}

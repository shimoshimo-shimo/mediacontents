using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    // UI TextéwíËóp
    public Text TextFrame;
    // ï\é¶Ç∑ÇÈïœêî
   

    // Use this for initialization
    void Start()
    {
        TextFrame.text = string.Format(GlobalVariables.HP, "HP");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
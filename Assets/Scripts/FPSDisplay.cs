using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
 
public class FPSDisplay : MonoBehaviour
{
	public float timer, refresh, avgFramerate;
    public string display = "{0} fps";
    public TextMeshProUGUI m_Text;
 
	void Update()
	{
		float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if(timer <= 0) avgFramerate = (int) (1f / timelapse);
        m_Text.text = string.Format(display, avgFramerate.ToString());
 
    }
}
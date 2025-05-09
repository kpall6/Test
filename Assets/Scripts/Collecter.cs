using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Collecter : MonoBehaviour
{  
   [Serialization] Text countText;

    private int countMelon = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fruit"))
        {
            countMelon++;
            countText.text = "Score : " + countMelon;
            Destroy(other.gameObject);
        }
    }
}
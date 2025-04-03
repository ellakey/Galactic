using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerLetterCollector : MonoBehaviour
{
    [SerializeField] private string targetName = "ECHO";
    private string collected = "";
    [SerializeField] private TextMeshProUGUI nameCompleteText;
    [SerializeField] private Image wantedPoster;
    [SerializeField] private float delayBeforeNextScene = 2f;

    public void CollectLetter(char letter)
    {
        if (targetName.Contains(letter) && !collected.Contains(letter))
        {
            collected += letter;
            Debug.Log("Collected: " + collected);

            if (collected.Length >= targetName.Length)
            {
                Win();
            }
        }
    }

    void Win()
    {
        Debug.Log("You completed the name!");

        if (nameCompleteText != null)
        {
            nameCompleteText.text = targetName;
            nameCompleteText.gameObject.SetActive(true);
            wantedPoster.gameObject.SetActive(true);
        }

        StartCoroutine(TransitionAfterDelay());
    }

    IEnumerator TransitionAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeNextScene);
        SceneManager.LoadScene("Shooter"); // Replace with actual scene name
    }
}

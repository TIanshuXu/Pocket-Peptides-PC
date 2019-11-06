using UnityEngine;
using System.Collections;

public class HintManager : MonoBehaviour
{
    DropZone d; // for detect goal achieved flag
    bool isHint02Enabled; // flag

    static GameObject Highlight = null; // reference highlight object

    GameObject buttonPanel; // reference Button Panel

    private void Start()
    {
        d = GameObject.Find("Protein Drop Panel").GetComponent<DropZone>();
    }

    private void Update()
    {
        if (isHint02Enabled && d.IsGoalAchieved)
        { // player win, show 03 to guide player submit
            GameObject.Find("Hint02").SetActive(false);
            GameObject.Find("Canvas").transform.Find("Tutorial Panel").transform.Find("Hint03").gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        buttonPanel = GameObject.Find("Button Panel");

        if (Highlight != null)
        {
            Highlight.SetActive(false); // make sure it's off
        }
        // show highlight 4 sec then hide it
        if (gameObject.name == "Hint00")
        {
            StartCoroutine(ShowHighlightEffect(0)); // guide player to click ? button
            buttonPanel.transform.SetSiblingIndex(5); // move buttonPanel beneath mainPanel
            buttonPanel.transform.Find("HintButton").SetAsLastSibling(); // only hintButton interactable
        }
        if (gameObject.name == "Hint01")
        {
            StartCoroutine(ShowHighlightEffect(1));
            buttonPanel.transform.Find("HintButton").SetAsFirstSibling(); // move it back
            buttonPanel.transform.Find("QuestButton").SetAsLastSibling(); // only questButton interactable
        }
        if (gameObject.name == "Hint02")
        {
            isHint02Enabled = true;
            StartCoroutine(ShowHighlightEffect(2));
            buttonPanel.transform.Find("QuestButton").SetAsFirstSibling(); // move it back
            buttonPanel.transform.SetSiblingIndex(4); // move buttonPanel back
            buttonPanel.transform.Find("ResetButton").SetAsLastSibling(); // only resetButton interactable
        }
        else { isHint02Enabled = false; } // disable the flag
        if (gameObject.name == "Hint03")
        {
            StartCoroutine(ShowHighlightEffect(3));
            buttonPanel.transform.Find("ResetButton").SetSiblingIndex(2); // move it back
            buttonPanel.transform.SetSiblingIndex(5); // move buttonPanel beneath mainPanel again
            buttonPanel.transform.Find("SubmitButton").SetAsLastSibling(); // only submitButton interactable
        }
    }

    IEnumerator ShowHighlightEffect(int index)
    {
        switch (index) // assign highlight base on index
        {
            case 0:
                Highlight = GameObject.Find("Main Camera").transform.Find("Hint00 Highlight").gameObject;
                break;
            case 1:
                Highlight = GameObject.Find("Main Camera").transform.Find("Hint01 Highlight").gameObject;
                break;
            case 2:
                Highlight = GameObject.Find("Main Camera").transform.Find("Hint02 Highlight").gameObject;
                break;
            case 3:
                Highlight = GameObject.Find("Main Camera").transform.Find("Hint03 Highlight").gameObject;
                break;
            default:
                break;
        }
        Highlight.SetActive(true); // show highlight for 4 sec
        yield return new WaitForSeconds(3);
        Highlight.SetActive(false);
    }
}

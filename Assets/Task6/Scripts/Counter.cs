using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterUI;
    private int counter;
    private bool counterActive = false;

    public void StartCounting()
    {
        if(!counterActive)
        {
            counterActive = true;
            StartCoroutine(nameof(AddCount));
        }
        else
        {
            counterActive = false;
        }
    }
    IEnumerator AddCount()
    {
        counter += 1;
        counterUI.text = counter.ToString();
        yield return new WaitForSeconds(0.5f);
        if(counterActive)
            StartCoroutine(nameof(AddCount));
    }
}

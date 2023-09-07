using System.Collections;
using UnityEngine;

public class CatsGame : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
        StartCoroutine(WaitForIt());
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}

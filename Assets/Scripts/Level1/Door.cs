using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private FadeImage _fadeScript;
    [SerializeField]
    private float _fadeDuration = 1.5f;
    [SerializeField]
    private float _fadeWaitBefore = 0f;
    [SerializeField]
    private float _fadeWaitAfter = 8f;
    [SerializeField]
    private string _fadeText = "The sword will never depart from your house...\nYou did it in secret, but I will do this in broad daylight before all Israel.\n— 2 Samuel 12:10,12 (NIV)";

    private void OnTriggerEnter2D(Collider2D other)
    {
        _fadeScript.FadeOut(_fadeWaitBefore, _fadeWaitAfter, _fadeDuration, _fadeText, () =>
        {
            Application.Quit();
        });
    }
}

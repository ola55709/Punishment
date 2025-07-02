using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textObject;
    [SerializeField]
    private bool _fadeInOnStart = true;
    [SerializeField]
    private float _startFadeInDuration = 1.5f;
    [SerializeField]
    private float _startFadeInWaitBefore = 3f;
    [SerializeField]
    private float _startFadeInWaitAfter = 0f;
    [SerializeField]
    private string _startFadeInText = "Example";

    private Image _fadeImage;
    void Start()
    {
        _fadeImage = GetComponent<Image>();
        if (_fadeInOnStart)
        {
            FadeIn(_startFadeInWaitBefore, _startFadeInWaitAfter, _startFadeInDuration, _startFadeInText, () => { });
        }
    }

    public void FadeIn(float waitBefore, float waitAfter, float fadeDuration, string text, Action callback)
    {
        StartCoroutine(FadingIn(waitBefore, waitAfter, fadeDuration, text, callback));
    }

    public void FadeOut(float waitBefore, float waitAfter, float fadeDuration, string text, Action callback)
    {
        StartCoroutine(FadingOut(waitBefore, waitAfter, fadeDuration, text, callback));
    }

    IEnumerator FadingIn(float waitBefore, float waitAfter, float fadeDuration, string text, Action callback)
    {
        float time = 0f;
        Color color = _fadeImage.color;
        _fadeImage.color = new Color(color.r, color.g, color.b, 1);
        _textObject.alpha = 1f;
        _textObject.text = text;
        yield return new WaitForSeconds(waitBefore);
        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, time / fadeDuration);
            _textObject.alpha = alpha;
            _fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            time += Time.deltaTime;
            yield return null;
        }

        _fadeImage.color = new Color(color.r, color.g, color.b, 0f);
        _textObject.alpha = 0f;
        yield return new WaitForSeconds(waitAfter);

        callback();
    }

    IEnumerator FadingOut(float waitBefore, float waitAfter, float fadeDuration, string text, Action callback)
    {
        float time = 0f;
        Color color = _fadeImage.color;
        _fadeImage.color = new Color(color.r, color.g, color.b, 0);
        _textObject.alpha = 0f;
        _textObject.text = text;
        yield return new WaitForSeconds(waitBefore);
        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, time / fadeDuration);
            _fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            _textObject.alpha = alpha;
            time += Time.deltaTime;
            yield return null;
        }

        _fadeImage.color = new Color(color.r, color.g, color.b, 1f);
        _textObject.alpha = 1f;

        yield return new WaitForSeconds(waitAfter);

        callback();
    }

}

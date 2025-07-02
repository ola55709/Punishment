using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RandomImagery : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _images;
    [SerializeField]
    private float _minInterval = 1f;
    [SerializeField]
    private float _maxInterval = 5f;
    [SerializeField]
    private float minDuration = 0.1f;
    [SerializeField]
    private float maxDuration = 0.5f;
    [SerializeField]
    private int _minSize = 100;
    [SerializeField]
    private int _maxSize = 300;
    [SerializeField]
    private float _minAlpha = 0.05f;
    [SerializeField]
    private float _maxAlpha = 0.2f;

    private Canvas _canvas;

    void Start()
    {
        _canvas = GetComponent<Canvas>();
        StartCoroutine(FlashImages());
    }

    IEnumerator FlashImages()
    {
        while (true)
        {
            float waitTime = Random.Range(_minInterval, _maxInterval);
            yield return new WaitForSeconds(waitTime);

            Sprite img = _images[Random.Range(0, _images.Length)];

            GameObject go = new GameObject("FlashImage");
            go.transform.SetParent(_canvas.transform, false);

            Image imageComp = go.AddComponent<Image>();
            imageComp.sprite = img;

            var sizeRand = Random.Range(_minSize, _maxSize);
            Vector2 size = new Vector2(sizeRand, sizeRand);
            RectTransform rt = go.GetComponent<RectTransform>();
            rt.sizeDelta = size;

            float x = Random.Range(0f, Screen.width);
            float y = Random.Range(0f, Screen.height);
            rt.anchoredPosition = new Vector2(x - Screen.width / 2f, y - Screen.height / 2f);

            float alpha = Random.Range(_minAlpha, _maxAlpha);
            Color c = imageComp.color;
            c.a = alpha;
            imageComp.color = c;

            float duration = Random.Range(minDuration, maxDuration);
            Destroy(go, duration);
        }
    }
}

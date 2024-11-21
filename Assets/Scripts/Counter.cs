using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class Counter : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _timeStepInSeconds = 0.5f;

    private int _count;
    private bool _isCounter;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCounter = !_isCounter;

            if (_isCounter)
            {
                StopAllCoroutines();
                StartCoroutine(Countup());
            }
        }
    }

    private IEnumerator Countup()
    {
        while (_isCounter)
        {
            yield return new WaitForSeconds(_timeStepInSeconds);

            ++_count;
            _text.text = _count.ToString();
        }
    }
}
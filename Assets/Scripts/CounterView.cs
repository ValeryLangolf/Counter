using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(Counter))]
public class CounterView : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private Counter _counter;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _counter = GetComponent<Counter>();
    }

    private void OnEnable()
    {
        _counter.CountChanged += ShowCount;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= ShowCount;
    }

    private void ShowCount(int count)
    {
        _text.text = count.ToString();
    }
}
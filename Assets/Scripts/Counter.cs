using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _timeStepInSeconds = 0.5f;

    public event Action<int> CountChanged;

    private int _count;
    private bool _isCounter;
    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCounter = !_isCounter;

            if (_isCounter)
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                    _coroutine = null;
                }

                _coroutine = StartCoroutine(Countup());
            }
        }
    }

    private IEnumerator Countup()
    {
        WaitForSeconds timeStep = new WaitForSeconds(_timeStepInSeconds);

        while (_isCounter)
        {
            yield return timeStep;

            ++_count;
            CountChanged?.Invoke(_count);            
        }
    }
}
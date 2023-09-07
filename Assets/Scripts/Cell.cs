using System;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public event EventHandler Click;

    private TMPro.TextMeshPro _text;

    public bool IsEnabled { get; set; } = true;

    public void SetText(string text)
    {
        if (_text == null)
        {
            _text = GetComponentInChildren<TMPro.TextMeshPro>();
        }

        _text.text = text;
    }

    private void OnMouseDown()
    {
        if (!IsEnabled) return;

        Click?.Invoke(this, EventArgs.Empty);
    }
}

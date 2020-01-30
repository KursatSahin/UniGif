using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GifImage : RawImage
{
    private string url;

    [SerializeField]
    private UniGifImage m_uniGifImage; 
    
    private bool m_mutex;
    
    public string Url
    {
        get => url;
        set => url = value;
    }
    
    
    public void Run()
    {
        if (TryGetComponent(out UniGifImage ugi))
        {
            m_uniGifImage = ugi;
        }
        
        if (m_mutex || m_uniGifImage == null || string.IsNullOrEmpty(url))
        {
            Debug.Log(nameof(Run) +  "()-> string::Url, Component::UniGifImage or bool::mutex has invalid value");
            return;
        }

        m_mutex = true;

        StartCoroutine(ViewGifCoroutine());
    }

    private IEnumerator ViewGifCoroutine()
    {
        yield return StartCoroutine(m_uniGifImage.SetGifFromUrlCoroutine(url));
        m_mutex = false;
    }
}

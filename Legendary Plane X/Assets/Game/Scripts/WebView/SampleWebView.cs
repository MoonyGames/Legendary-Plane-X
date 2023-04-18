using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SampleWebView : MonoBehaviour
{
    public static string URL;

    private static WebViewObject _webViewObject;

    private void Awake()
    {
        OrientationManager.orientationChangedEvent += RefreshMargins;
    }

    public static IEnumerator CreateWebView()
    {
        _webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        _webViewObject.Init(
            cb: (msg) =>
            {
            },
            err: (msg) =>
            {
            },
            ld: (msg) =>
            {
#if !UNITY_ANDROID
#if true
                _webViewObject.EvaluateJS(@"
                  if (window && window.webkit && window.webkit.messageHandlers && window.webkit.messageHandlers.unityControl) {
                    window.Unity = {
                      call: function(msg) {
                        window.webkit.messageHandlers.unityControl.postMessage(msg);
                      }
                    }
                  } else {
                    window.Unity = {
                      call: function(msg) {
                        window.location = 'unity:' + msg;
                      }
                    }
                  }
                ");
#else
                webViewObject.EvaluateJS(@"
                  if (window && window.webkit && window.webkit.messageHandlers && window.webkit.messageHandlers.unityControl) {
                    window.Unity = {
                      call: function(msg) {
                        window.webkit.messageHandlers.unityControl.postMessage(msg);
                      }
                    }
                  } else {
                    window.Unity = {
                      call: function(msg) {
                        var iframe = document.createElement('IFRAME');
                        iframe.setAttribute('src', 'unity:' + msg);
                        document.documentElement.appendChild(iframe);
                        iframe.parentNode.removeChild(iframe);
                        iframe = null;
                      }
                    }
                  }
                ");
#endif
#endif
                _webViewObject.EvaluateJS(@"Unity.call('ua=' + navigator.userAgent)");
            },
            enableWKWebView: true);
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        _webViewObject.bitmapRefreshCycle = 1;
#endif
        _webViewObject.SetMargins(0, 100, 0, 0);
        _webViewObject.SetVisibility(true);

#if !UNITY_WEBPLAYER
        if (URL.StartsWith("http"))
            _webViewObject.LoadURL(URL.Replace(" ", "%20"));

        else
        {
            string[] exts = new string[]{
                ".jpg",
                ".js",
                ".html"
            };

            foreach (string ext in exts)
            {
                string url = URL.Replace(".html", ext);

                string src = System.IO.Path.Combine(Application.streamingAssetsPath, url);
                string dst = System.IO.Path.Combine(Application.persistentDataPath, url);

                byte[] result = null;

                if (src.Contains("://"))
                {
                    WWW www = new WWW(src);

                    yield return www;

                    result = www.bytes;
                }

                else
                    result = System.IO.File.ReadAllBytes(src);

                System.IO.File.WriteAllBytes(dst, result);

                if (ext == ".html")
                {
                    _webViewObject.LoadURL("file://" + dst.Replace(" ", "%20"));
                    break;
                }
            }
        }
#else
        if (Url.StartsWith("http")) {
            webViewObject.LoadURL(Url.Replace(" ", "%20"));
        } else {
            webViewObject.LoadURL("StreamingAssets/" + Url.Replace(" ", "%20"));
        }
        webViewObject.EvaluateJS(
            "parent.$(function() {" +
            "   window.Unity = {" +
            "       call:function(msg) {" +
            "           parent.unityWebView.sendMessage('WebViewObject', msg)" +
            "       }" +
            "   };" +
            "});");
#endif

        yield break;
    }

    private void RefreshMargins()
    {
        _webViewObject.SetMargins(0, 100, 0, 0);
    }

    public void GoBackButton()
    {
        _webViewObject.GoBack();
    }

    public void GoForwardButton()
    {
        _webViewObject.GoForward();
    }

    public void ReloadButton()
    {
        _webViewObject.Reload();
    }
}

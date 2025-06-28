using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MessageFrame : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float _timeBetweenLettters = 0.05f;

    [SerializeField]
    private float _timeToHide = 2f;

    [SerializeField]
    private string _showAnimationName = "ShowMessageFrame";

    [SerializeField]
    private string _hideAnimationname = "HideMesaggeFrame";

    private string _curretText;

    private Coroutine _typingCoroutine;

    public static MessageFrame Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowMessage(string message)
    {
        StopCoroutine();
        _curretText = message;
        _text.text = "";
        _animator.Play(_showAnimationName, 0, 0f);
        _typingCoroutine = StartCoroutine(TypeMessage());
    }

    private IEnumerator TypeMessage()
    {
        for (int i = 0; i < _curretText.Length; i++)
        {
            _text.text += _curretText[i];
            yield return new WaitForSeconds(_timeBetweenLettters);
        }
        yield return new WaitForSeconds(_timeToHide);
        _animator.Play(_hideAnimationname, 0, 0f);
    }

    private void StopCoroutine()
    {
        if (_typingCoroutine != null)
        {
            StopCoroutine(_typingCoroutine);
            _typingCoroutine = null;
        }
    }

    public void StopMesage()
    {
        StopCoroutine();
        _animator.Play(_hideAnimationname, 0, 0f);
        _text.text = "";
    }
}

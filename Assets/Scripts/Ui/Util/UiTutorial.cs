using UnityEngine;
using UnityEngine.UI;

public class UiTutorial : MonoBehaviour
{
    [SerializeField] Button close;
    [SerializeField] GameObject content;
    void Awake() => close.onClick.AddListener(Close);
    void Close() => content.SetActive(false);
}
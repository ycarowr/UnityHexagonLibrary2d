using System.Collections.Generic;
using HexBoardGame.UI;
using Tools.Patterns.Singleton;
using UnityEngine;

public interface IBackHandler
{
    void Show();
    void Back();
}

public class BackButton : SingletonMB<BackButton>
{
    private readonly Stack<IBackHandler> _windows = new Stack<IBackHandler>();

    [SerializeField] private UiMenu uiMenu;

    public void Push(IBackHandler window)
    {
        _windows?.Push(window);
    }

    public void Clear()
    {
        _windows.Clear();
    }

    public void Pop()
    {
        if (_windows.Count < 1)
            return;
        var window = _windows.Pop();
        window.Back();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_windows.Count < 1)
                uiMenu.Show();
            else
                Pop();
        }
    }
}
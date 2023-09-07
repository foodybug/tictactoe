using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    private bool _playing = false;
    public Cell[] _cells;
    //public TMPro.TextMeshProUGUI _token;
    //public Button _newGame;
    //public CatsGame _catsGame;
    //public Victory _victory;

    System.Random rnd;

    private string[] _tokens = new string[] { "X", "0" };
    private int _currentToken = 0; public int currentToken { get { return _currentToken; } }

    private TicTacToeEngine _engine = new TicTacToeEngine();

    void Awake()
    {
        foreach (var cell in _cells)
        {
            cell.Click += (o, e) =>
              {
                  var index = Array.IndexOf(_cells, o);
                  Clicked(index);
              };
            cell.SetText("");
        }
    }

    public void NewGame()
    {
        _currentToken = 0;
        //_token.text = _tokens[_currentToken];
        //_newGame.interactable = false;
        _playing = true;
        _engine.NewGame();
        rnd = new System.Random();

        foreach (var cell in _cells)
        {
            cell.SetText("");
            cell.IsEnabled = true;
        }
    }

    private void Clicked(int index)
    {
        if (!_playing) return;

        _cells[index].SetText(_tokens[_currentToken]);
        _currentToken++;
        _currentToken %= 2;
        //_token.text = _tokens[_currentToken];

        _engine.Place(index);
        _cells[index].IsEnabled = false;

        var winner = _engine.IsVictory();
        if (winner == -1)
        {
            CatsGame();
        }
        else if (winner > 0)
        {
            WinnerIs(winner - 1);
        }
    }

    public int GetClicked()
	{
        if (!_playing)
            return -1;

        int index = rnd.Next(0, _cells.Length);
        _cells[index].SetText(_tokens[_currentToken]);
        _currentToken++;
        _currentToken %= 2;
        //_token.text = _tokens[_currentToken];

        _engine.Place(index);
        _cells[index].IsEnabled = false;

        var winner = _engine.IsVictory();
        if (winner == -1)
        {
            CatsGame();
        }
        else if (winner > 0)
        {
            WinnerIs(winner - 1);
        }
    }

    private void WinnerIs(int id)
    {
        EndOfGame();
        //_victory.Show(_tokens[id]);
    }


    private void CatsGame()
    {
        EndOfGame();
        //_catsGame.Show();
    }

    private void EndOfGame()
    {
        //_newGame.interactable = true;
        foreach (var cell in _cells)
        {
            cell.IsEnabled = false;
        }
    }
}

﻿using Classes.SudokuTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Memento
{
    public class SudokuCaretaker
    {
        private Sudoku _sudoku;

        private List<ISnapshot> mementos = new List<ISnapshot>();

        public SudokuCaretaker(Sudoku sudoku)
        {
            this._sudoku = sudoku;
        }

        public void SaveBackup()
        {
            mementos.Add(_sudoku.Save());
        }

        public bool Restore()
        {
            if (mementos.Any())
            {
                var snapshot = mementos.Last();
                _sudoku.Restore(snapshot);
                mementos.Remove(snapshot);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ChangeSudoku(Sudoku sudoku) 
        {
            _sudoku = sudoku;
            mementos.Clear();
        }

    }
}

using Sudoku.Shared;

namespace Sudoku.ResolutionTechniquesHumaines
{
    public class ResolutionTechniquesHumaines : ISudokuSolver
    {
        public SudokuGrid Solve(SudokuGrid s)
        {

            // Convertir SudokuGrid en int[][]
            int[][] sudokuArray = new int[9][];
            for (int row = 0; row < 9; row++)
            {
                sudokuArray[row] = new int[9];
                for (int col = 0; col < 9; col++)
                {
                    sudokuArray[row][col] = s.Cells[row][col];
                }
            }

            Puzzle puzzle = new Puzzle(sudokuArray, false);

            Solver solver = new Solver(puzzle);

            // Appeler la méthode de résolution du solveur
            solver.TrySolve(); 

            return s;
        }
    }
}

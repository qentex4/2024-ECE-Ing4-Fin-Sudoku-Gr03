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

            // Appeler la m�thode de r�solution du solveur
            solver.TrySolve();



            // Cr�er un tableau 2D pour stocker le sudoku r�solu
            int[][] solvedSudokuArray = new int[9][];

            // Parcourir chaque ligne et colonne du puzzle pour r�cup�rer les valeurs des cellules r�solues
            for (int row = 0; row < 9; row++)
            {
                solvedSudokuArray[row] = new int[9];
                for (int col = 0; col < 9; col++)
                {
                    // Acc�der � chaque cellule du puzzle et r�cup�rer sa valeur r�solue
                    int cellValue = solver.Puzzle[col, row].Value;

                    // Stocker la valeur dans le tableau 2D
                    solvedSudokuArray[row][col] = cellValue;
                }
            }

            // Afficher le Sudoku r�solu en inversant lignes et colonnes
            Console.WriteLine("Sudoku r�solu :");
            for (int col = 0; col < 9; col++)
            {
                for (int row = 0; row < 9; row++)
                {
                    Console.Write(solvedSudokuArray[row][col] + " ");
                }
                Console.WriteLine();
            }

            // Convertir int[][] en SudokuGrid avec inversion des lignes et des colonnes
            SudokuGrid solvedSudokuGrid = new SudokuGrid();
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    solvedSudokuGrid.Cells[col][row] = solvedSudokuArray[row][col];
                }
            }


            s = solvedSudokuGrid;

            return s;
        }
    }
}

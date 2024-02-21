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



            // Créer un tableau 2D pour stocker le sudoku résolu
            int[][] solvedSudokuArray = new int[9][];

            // Parcourir chaque ligne et colonne du puzzle pour récupérer les valeurs des cellules résolues
            for (int row = 0; row < 9; row++)
            {
                solvedSudokuArray[row] = new int[9];
                for (int col = 0; col < 9; col++)
                {
                    // Accéder à chaque cellule du puzzle et récupérer sa valeur résolue
                    int cellValue = solver.Puzzle[col, row].Value;

                    // Stocker la valeur dans le tableau 2D
                    solvedSudokuArray[row][col] = cellValue;
                }
            }

            // Afficher le Sudoku résolu en inversant lignes et colonnes
            Console.WriteLine("Sudoku résolu :");
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

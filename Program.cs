﻿using Board;
using GamePieces;
using Utils;

ChessBoard chessBoard = new ChessBoard();
chessBoard.SetUpBoard();
Console.WriteLine("Initial Chess Board Setup:");
chessBoard.DisplayBoard();
Console.WriteLine();
while (true)
{
    Console.WriteLine("Enter your move (e.g., e2 e4): ");
    string move = Console.ReadLine()!;
    if (move.ToLower() == "exit")
    {
        break;
    }
    else if (move.ToLower() == "reset")
    {
        chessBoard.SetUpBoard();
        Console.WriteLine("Chess Board Reset:");
        chessBoard.DisplayBoard();
        continue;
    }
    Console.WriteLine();
    if (move != null)
    {
        string[] positions = move.Split(' ');
        if (positions.Length == 2)
        {
            string fromPosition = positions[0];
            string toPosition = positions[1];

            ChessPiece piece = BoardUtils.PositionToPiece(chessBoard, fromPosition);
            if (piece != null && piece.IsValidMove(chessBoard, fromPosition, toPosition))
            {
                Console.WriteLine($"Valid move from {fromPosition} to {toPosition}");
                piece.MovePiece(chessBoard, fromPosition, toPosition);

                Console.WriteLine("After Move:");
                chessBoard.DisplayBoard();

            }
            else
            {
                Console.WriteLine($"Invalid move from {fromPosition} to {toPosition}");
            }
        }
    }
}
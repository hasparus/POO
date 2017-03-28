using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Lista_3.Hyperchess.Piece;

namespace Lista_3.Hyperchess
{
    namespace Piece
    {
        public struct Point<T>
        {
            public T x;
            public T y;
        }

        public struct Move
        {
            public Point<byte> start;
            public Point<byte> end;
        }

        /// <summary>
        /// Controller. Nie jest w GUI, ale dostaje od interfejsu eventy o akcjach użytkownika.
        /// Obsługuje je, ewentualnie deleguje je dalej.
        /// To można by tu nazwać jak UseCaseController
        /// PieceTouchController albo PieceTouchHandler
        /// Odpowiada za wykonanie tego scenariusza.
        /// </summary>
        class PieceController
        {
            Move _currentMove;
            Piece piece;

            public void OnPickUp(Piece piece) 
            // Ewentualnie zamiast wywoływać z GUI OnMouseDown -> OnMouseDown, można tu napisać OnPickUp
            {
                this.piece = piece;
                _currentMove = new Move
                {
                    start = Board.GetPosition(piece.Id)
                };
            }

            public void OnPutDown()
            {
                _currentMove.end = Board.GetPosition(piece.Id);
                if (piece.CanExecute(_currentMove) && Board.IsMovePossible(_currentMove))
                {
                    var otherPieceId = Board.DoMove(piece.Id, _currentMove);
                    if (otherPieceId.HasValue)
                    {
                        piece.Interact(Piece.Collection[otherPieceId.Value]);
                    }
                }
                // Log Moves.
            }
        }

        abstract class Piece
        {
            public static Dictionary<int, Piece> Collection;
            const int Limit = byte.MaxValue;

            public readonly int Id;

            static int _highestPieceId;
            protected Piece()
            {
                Id = ++_highestPieceId;
                Collection[_highestPieceId] = this;
            }

            ~Piece()
            {
                Collection[Id] = null;
            }

            // Sprawdza czy ruch jest legalny w ogóle ORAZ w aktualnym stanie figury.
            public abstract bool CanExecute(Move move);
            public abstract void Interact(Piece other);
        }

        class Rook : Piece
        {
            const int Limit = 2;
            public override bool CanExecute(Move move) => 
                move.start.x == move.end.x || move.start.y == move.end.y;

            public override void Interact(Piece other)
            {
                var otherDurable = other as IDurablePiece;
                if (otherDurable != null)
                    otherDurable.GetDamaged();
                else
                {
                    other = null;
                }
            }
        }

        interface IDurablePiece
        {
            int Health { get; }
            void GetDamaged();
        }

        class Warlock : Piece, IDurablePiece
        {
            const int Limit = 1;
            public int Health { get; private set; } = 5;

            public void GetDamaged()
            {
                Health--;
            }

            void DoSuperFancyStuff()
            {
            }

            public override bool CanExecute(Move move) => 
                Health % 2 == move.start.x + move.end.y % 2;

            public override void Interact(Piece other)
            {
                other = null;
            }

            // Tak. Potrzebowałem wytłumaczenia czemu to nie jest static.
            
        }
    }

    class Square
    {
        public int? Occupant;

        public enum TerrainType
        {
            Grassland = 0,
            Marsh = 1,
            Mountain = 2
        }

        public TerrainType terrainType;
    }

    /// <summary>
    /// No i tu wydaje mi się, że Low Coupling całkiem mi wyszło.
    /// Plansza nie musi mieć pojęcia że istnieje coś takiego jak Figura,
    ///     wystarczy, że pamięta, że na jej polach leżą jakieś liczby całkowite.
    /// 
    /// Używamy tu Planszy jako InformationExperta odnośnie stanu pól i zmieniania pozycji figur,
    /// ale rusza jedynie kluczami, bo nie ma powodów wywoływać metod figur.
    /// Trzymamy metodę blisko danych na których działa.    
    /// </summary>
    class Board
    {
        static Square[,] board;
        static Dictionary<int, Point<byte>> positions; 

        public static bool IsMovePossible(Move move)
        {
            return IsOnBoard(move.start) && IsOnBoard(move.end);
        }

        static int? GetOccupant(Point<byte> point)
        {
            return board[point.x, point.y].Occupant;
        }

        static void SetOccupant(Point<byte> point, int? Id)
        {
            board[point.x, point.y].Occupant = Id;
        }

        public static int? DoMove(int moverId, Move move)
        {
            SetOccupant(move.start, null);
            var lastOccupant = GetOccupant(move.end);
            SetOccupant(move.end, moverId);
            return lastOccupant;
        }

        static bool IsOnBoard(Point<byte> point)
        {
            //bad design, wystarczyłoby inty porównywać, ale to poniżej mnie zbyt bawi
            try
            {
                var square = board[point.x, point.y];
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Point<byte> GetPosition(int pieceId)
        {
            return positions[pieceId];
        }
    }
}

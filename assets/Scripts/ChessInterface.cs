using UnityEngine;
using System.Collections;
public interface ChessInterface
{
    void Reset();
    void undo();
    void undo(int number);
    bool selectUser(int i,int j);
    bool moveUser(int i, int j);
}

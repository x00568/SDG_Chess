using UnityEngine;
using System.Collections; 
public interface ChessMethod {
    void StartGame();
    void Reset();
    void undo();
    void undo(int number);
    bool selectUser(int i,int j);
    bool moveUser(int i, int j);
}

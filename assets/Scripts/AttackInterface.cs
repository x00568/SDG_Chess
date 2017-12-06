using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AttackInterface
{
    //将位置转化为坐标信息
    int numAttacking(Vector2 pos);
    //计算攻击数
    int numAttacking(int i, int j);
    //将位置转化为坐标信息
    bool isAttacked(Vector2 pos);
    //判断是否被攻击
    bool isAttacked(int i, int j);
    //生成表格，对表格进行标记
    void generateTable(side attacker);


}

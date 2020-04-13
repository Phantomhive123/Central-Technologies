using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicLoop : MonoBehaviour
{
    /*
     * 一、游戏循环的基本逻辑
     * while(true)
     * {
     *     Input();
     *     Update();
     *     Render();
     * }
     * 
     * 二、固定帧率模式
     * while(true)
     * {
     *     double start = getCurrentTime();
     *     
     *     Input();
     *     Update();
     *     Render();
     *     
     *     sleep(start + 1/FPS - getCurrentTime());
     * }
     * 
     * 三、追赶模式
     * double preFrameTime = getCurrentTime();
     * double lag = 0.0;
     * while(true)
     * {
     *     double current = getCurrentTime();
     *     double elapsed = current - preFrameTime;
     *     preFrameTime = current;
     *     lag += elapsed;
     *     
     *     Input();
     *     
     *     while(lag>=1/FPS)
     *     {
     *          Update();
     *          lag -= 1/FPS;
     *     }
     *     
     *     Render();
     * }
     */
}

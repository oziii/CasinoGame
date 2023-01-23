using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OziLib
{
    public sealed class EventTags
    {
        //Test Action
        static public string TEST = "TEST";
        static public string TEST_DATA = "TEST_DATA";
        static public string TEST_I = "TEST_I";

        //Game Action
        static public string LEVEL_READY = "LEVEL_READY";
        static public string LEVEL_START = "LEVEL_START";
        static public string LEVEL_FAIL = "LEVEL_FAIL";
        static public string LEVEL_COMPLETE = "LEVEL_COMPLETE";
        static public string LEVEL_END = "LEVEL_END";
        static public string LEVEL_EXIT = "LEVEL_EXIT";
        static public string COLLECT_REWARD = "COLLECT_REWARD";
        static public string NEXT_LEVEL = "NEXT_LEVEL";
        static public string LEVEL_RESTART = "LEVEL_RESTART";
        static public string SPIN_START = "SPIN_START";
        static public string SPIN_END = "SPIN_END";
        
        

        static public string COIN_COLLECT = "COIN_COLLECT";
        //Camera Action
        static public string CAMERA_SHAKE = "CAMERA_SHAKE";
        static public string CAMERA_CHANGE = "CAMERA_CHANGE";
        //Special Action

        //Data Name
        static public string LEVEL_COUNTER = "LEVEL_COUNTER";
        static public string COIN_COUNTER = "COIN_COUNTER";

        //Const Data
    }
}
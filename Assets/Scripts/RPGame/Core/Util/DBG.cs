using UnityEngine;
using System.Collections;

namespace Assets.Scripts.RPGame.Core.Util
{

    public class Error
    {
        public enum TYPE : int
        {
            INVALID_ERROR_TYPE = -1,
            UNABLE_TO_LOAD,
            COMPONENT_NOT_FOUND,
        }
        public TYPE ErrorType;
        public string Subject;
        public string Message;
        public string Comment;

        public Error newError(TYPE type, string subject = "", string comment = "")
        {
            Error e = new Error();
            e.ErrorType = type;
            e.Subject = subject;
            e.Comment = comment;
            e.Message = (e.ErrorType == TYPE.COMPONENT_NOT_FOUND) ? "<< Component Not Found >> " :
                            (e.ErrorType == TYPE.UNABLE_TO_LOAD) ? "<< Unable To Load >> " :
                            /* Default: */    "<< Invalid Error Type! Something Went Wrong >> ";
            return e;
        }
    }
    public static class DBG
    {
        public static bool Logging = false;
        public static bool Paused = false;
        public static bool ShowingErrors = true;

        public static void Enable() { Logging = true; }
        public static void Disable() { Logging = false; }
        public static void ToggleLog() { Logging = !Logging; }
        
        public static void Pause() { Paused = true; }
        public static void Unpause() {
            Paused = false;
        }
        public static void TogglePause() { Paused = !Paused; }

        public static void ShowErrors() { ShowingErrors = true; }
        public static void HideErrors() { ShowingErrors = false; }
        public static void ToggleShowErrors() { ShowingErrors = !ShowingErrors; }
        
        private static string _msg = "", _cache = "";
        public static void Add(string msg, bool newline = false) {
            _msg += (newline && _msg != "") ? "\n" + msg : msg;
        }
        public static void Cache(string msg) { _cache += msg; }
        public static void Clear() { _msg = ""; }

        public static void Log(bool force = false, bool clearAfter = true)
        {
            if (_msg != "") Log(_msg, force);
            if (clearAfter) Clear();
        }
        public static void Log(string msg, bool force = false) {
            if ((Logging || force)) {
                    Debug.Log(msg+"\n");
            }
        }
        public static void Log(rpElement element, string msg, bool force = false)
        {
            Log(element.ID + msg, force);
        }
        public static void Log(GameObject obj, string msg, bool force = false)
        {
            Log(obj.name + msg, force);
        }
        public static void Log(Transform tr, string msg, bool force = false)
        {
            Log(tr.name + msg, force);
        }

        public static void Log(Error e)
        {
            Add("<< ERROR >> ");
            Add("Message: " + e.Message, true);
            if (e.Subject != "") Add("Subject: " + e.Subject, true);
            if (e.Comment != "") Add("Comment: " + e.Comment, true);
            Log(ShowingErrors);
        }
    }
}

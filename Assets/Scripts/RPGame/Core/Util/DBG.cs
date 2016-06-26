using UnityEngine;
using System.Collections;

namespace RPGame.Core.Util
{
    
    public class Error {
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

        public Error newError(TYPE type,  string subject = "", string comment = "") {
            Error e = new Error();
            e.ErrorType = type;
            e.Subject = subject;
            e.Comment = comment;
            e.Message = (e.ErrorType == TYPE.COMPONENT_NOT_FOUND) ? "<< Component Not Found >> " :
                            (e.ErrorType == TYPE.UNABLE_TO_LOAD)      ? "<< Unable To Load >> " :
                            /* Default: */    "<< Invalid Error Type! Something Went Wrong >> " ;
            return e;
        }    
    }
    public static class DBG
    {
        public static bool Logging = false;
        public static bool ShowErrors = true;

        public static void Log(string msg) {
            if (Logging) Debug.Log(msg);
        }
        public static void Log(rpElement element, string msg) {
            if (Logging) Debug.Log(element.ID + msg);
        }
        public static void Log(GameObject obj, string msg) {
            if (Logging) Debug.Log(obj.name + msg);
        }
        public static void Log(Transform tr, string msg) {
            if (Logging) Debug.Log(tr.name + msg);
        }
        public static void Log(Error e) {
            if (Logging || ShowErrors) {
                string msg = "";
                msg += e.Message;
                msg += e.Subject != "" ? " (" + e.Subject + ") " : "";
                msg += e.Comment != "" ? "\"" + e.Comment + "\"" : "";
                Debug.Log("ERROR: " + msg);
            }
        }
    }
}

using UnityEngine;

namespace BreadAndButter
{
    public class SceneFieldsAttribute : PropertyAttribute
    {
        public static string LoadableName(string _path)
        {
            // pieces of the path we are looking to ignore
            string start = "Assets/";
            string end = ".unity";

            //test if the path contains the names 'start'
            if (_path.StartsWith(start))
            {
                _path = _path.Substring(start.Length);
            }
            if (_path.EndsWith(end))
            {
                _path = _path.Substring(0, end.LastIndexOf(end));
            }

            return _path;
        }


        
    
    }
}
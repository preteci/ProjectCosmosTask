using System.Runtime.Serialization;

namespace BLL.Execptions
{
    [Serializable]
    public class ProjectNotFoundException : Exception
    {
        public ProjectNotFoundException(string message) : base(message) { }
     
    }
}
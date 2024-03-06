using System.Runtime.Serialization;

namespace BLL.Execptions
{
    [Serializable]
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException(string message) : base(message) { }

    }
}

using System.ComponentModel;

namespace TaskApi.Enums
{
    public enum TaskStatus
    {
        [Description("To do")]
        ToDo = 1,

        [Description("Doing")]
        Doing = 2,

        [Description("Finished")]
        Completed = 3
    }
}

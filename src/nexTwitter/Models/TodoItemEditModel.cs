using System;

namespace nexTwitter.Models
{
    public class TodoItemEditModel
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public int Priority { get; set; }
    }
}
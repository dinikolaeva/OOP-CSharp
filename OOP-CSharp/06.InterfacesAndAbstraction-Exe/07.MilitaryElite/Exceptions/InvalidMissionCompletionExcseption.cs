using System;

namespace _07.MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionExcseption : Exception
    {
        private const string EXC_MESSAGE = "You cannot finish alredy completed mission.";

        public InvalidMissionCompletionExcseption()
            :base(EXC_MESSAGE)
        {

        }

        public InvalidMissionCompletionExcseption(string message) 
            : base(message)
        {
        }
    }
}

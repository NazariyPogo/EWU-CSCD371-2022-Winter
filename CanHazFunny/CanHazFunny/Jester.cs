using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    internal class Jester
    {
        private JokeOutput _jokeOutput;
        private JokeService _jokeService;

        public Jester(JokeOutput jokeOutput, JokeService jokeService)
        {
            _jokeOutput = jokeOutput;
            _jokeService = jokeService;
        }

        public void TellJoke()
        {
            JokeService jokeService = new JokeService();
            jokeService.GetJoke();
            while(jokeService.GetJoke().Contains("Chuck Norris"))
            {
                jokeService = new JokeService();
            }
        }
    }
}

using System;

namespace CanHazFunny
{
    internal class Jester
    {
        private IJokeOutput JokeOutput { get; set; }
        private IJokeService JokeService { get; set; }

        public Jester(IJokeOutput jokeOutput, IJokeService jokeService)
        {
            JokeOutput = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));
            JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeOutput));
        }

        public void TellJoke()
        {
            string joke = JokeService.GetJoke();
            while (joke.Contains("Chuck Norris"))
            {
                joke = JokeService.GetJoke();
            }
            JokeOutput.PrintJoke(joke);
        }
    }
}

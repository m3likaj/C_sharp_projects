int max = 50, min = 0;
int guess = 0;
void HumanGuess(){
    var rand  = new Random();
    int totalTrials = 10, trial=0;
    int num = rand.Next(min,max);
    Console.WriteLine($"I have a number between {min} and {max}. Try to guess the number in less than {totalTrials} guesses.");
   
    while(guess!=num && trial < totalTrials){
         Console.Write("Enter a guess: ");
         guess = Convert.ToInt32(Console.ReadLine());
         if(guess>num){
            Console.WriteLine("Your guess is too high!");
         }
         else if (guess< num){
            Console.WriteLine("Your guess is too low!");
         }
         trial++;
    }
    if(guess==num){
         Console.WriteLine("Congratulations! You have found the number!");
    }
    else{
        Console.WriteLine("You have run out of guesses! The number was" + num);
    }
   
   
}

void ComputerGuess() {
    bool end = false;
    char feedback;
    Console.Write("Enter the lower bound: ");
    min = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the upper bound: ");
    max = Convert.ToInt32(Console.ReadLine());
    while(!end){
        guess = (max - min)/2;
        Console.WriteLine("My guess is " + guess);
        Console.WriteLine("Please give feedback. 'H' if i should guess higher, 'L' if lower, 'E' if equal, 'Q' to quit ");
        feedback = Convert.ToChar(Console.ReadLine());
        switch(feedback){
            case 'H':
            case 'h':
                min = guess;
                break;
            case 'L':
            case 'l':
                max = guess;
                break;
            case 'E':
            case 'e':
                Console.WriteLine("Hurrah!");
                end = true;
                break;
            case 'Q':
            case 'q':
                Console.WriteLine("Quitting program.");
                end = true;
                break;
            default:
                Console.WriteLine("Invalid Feedback!");
                break;
        }
    }
}

ComputerGuess();
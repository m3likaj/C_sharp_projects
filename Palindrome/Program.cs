Console.Write("Enter a word/phrase: ");
string input = Console.ReadLine();
string reversed = new string(input.ToCharArray().Reverse().ToArray());
if(input == reversed)
    Console.WriteLine("its a palindrome");
else
    Console.WriteLine("Its not a palindrome");
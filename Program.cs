using Quizzes;

internal class Program
{
  private static Quiz quiz = new Quiz(Helper.GetAvailableQuestions());
  enum Action { 
    Add = 1, 
    Play, 
    Exit
  }
  private static void Main(string[] args)
  {
    bool isActive = true;

    while (isActive)
    {
      Console.WriteLine("\nQuiz Application");
      Console.WriteLine("1. Add Question");
      Console.WriteLine("2. Play Quiz");
      Console.WriteLine("3. Exit");
      Console.Write("Enter an action: ");
      
      bool isValid = int.TryParse(Console.ReadLine(), out int action);

      switch ((Action)action)
      {
        case Action.Add:
          Add();
          break;
        case Action.Play:
          Play();
          break;
        case Action.Exit:
          isActive = false;
          break;
        default:
          Console.WriteLine("Not a valid response.");
          break;
      }
    }
  }

  private static void Add ()
  {
    string? text = null;
    string? answer = null;  
    
    while (string.IsNullOrWhiteSpace(text)) 
    {
      Console.Write("Enter the question: ");
      text = Console.ReadLine();
    }

    while (string.IsNullOrWhiteSpace(answer))
    {
      Console.Write("Enter the answer: ");
      answer = Console.ReadLine();
    }

    try 
    {
      quiz.AddQuestion(text, answer);
    } 
    catch (Exception e) 
    {
      Console.WriteLine(e.Message);
    }
  }

  private static void Play () {
    try 
    {
      quiz.Play();
    }
    catch (Exception e) 
    {
      Console.WriteLine(e.Message);
    }
  }
}
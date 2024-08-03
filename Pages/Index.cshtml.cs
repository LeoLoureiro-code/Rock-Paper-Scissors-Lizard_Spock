using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace Rock_Paper_Scissor_Lizard_Spock.Pages
{
    public class IndexModel : PageModel
    {

        public string[] options = { "rock", "paper", "scissors", "lizard", "spock" };

        [BindProperty]
        public static int Score { get; set; }
        [BindProperty]
        public  string GameMessage { get; set; }
        [BindProperty]
        public string ErrorMessage { get; set; }
        [BindProperty]
        public  string PlayerChoose { get; set; }
        [BindProperty]
        public string CpuChoose { get; set; }
      
        private readonly ILogger<IndexModel> _logger;
      
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Score = 0;
        }

        public void OnPost(string option)
        {


            PlayerChoose = option;
            if (PlayerChoose != null)
            {
                CpuChoose = CPUChoose();
                string result = DetermineWinner(PlayerChoose, CpuChoose);
                GameMessage = result;
                ErrorMessage = "";
               
            }
            else
            {
                ErrorMessage = "Choose an option";
            }
               
                

           
        }

        public string DetermineWinner(string userChoice, string computerChoice)
        {

            if (userChoice == computerChoice)
            {
                return "It's a tie!";
            }

            if ((userChoice == "rock" && (computerChoice == "scissors" || computerChoice == "lizard")) ||
                (userChoice == "paper" && (computerChoice == "rock" || computerChoice == "spock")) ||
                (userChoice == "scissors" && (computerChoice == "paper" || computerChoice == "lizard")) ||
                (userChoice == "lizard" && (computerChoice == "spock" || computerChoice == "paper")) ||
                (userChoice == "spock" && (computerChoice == "scissors" || computerChoice == "rock")))
            {

                Score++;
                return "You win!";
                
            }
            else
            {
                Score--;
                return "Computer wins!";
            }
        }

        public String CPUChoose()
        {
            Random random = new Random();
            string[] choices = options;
            int index = random.Next(choices.Length);
            return choices[index];
        }

       
    }
}
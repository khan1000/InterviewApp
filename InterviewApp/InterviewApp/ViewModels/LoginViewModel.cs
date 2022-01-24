using System.Threading.Tasks;
using MvvmHelpers.Interfaces;
using MvvmHelpers.Commands;
using Xamarin.Forms;
using InterviewApp.Views;

namespace InterviewApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public IAsyncCommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new AsyncCommand(LoginAsync);
        }

        private async Task LoginAsync()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}

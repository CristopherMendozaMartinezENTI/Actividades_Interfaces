using System;
using System.Threading.Tasks;

public class LoginUseCase : LoginRequester
{
    public void Login()
    {
        //Nos conectamos al servidor aqui
        //Cogemos el id del player 
        var userData = new UserData("Kris");

        EventDispatcherService.Instance.Dispatch(userData);
    }
}
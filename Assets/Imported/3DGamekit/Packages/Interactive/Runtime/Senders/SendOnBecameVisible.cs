namespace Gamekit3D.GameCommands
{

    public class SendOnBecameVisible : SendGameCommand
    {
        void OnBecameVisible()
        {
            Send();
        }
    }

}

namespace Gamekit3D.GameCommands
{

    public class SendOnBecameInvisible : SendGameCommand
    {
        void OnBecameInvisible()
        {
            Send();
        }
    }
}

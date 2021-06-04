using UnityEngine;

namespace Gamekit3D.GameCommands
{

    public class SendOnTriggerExit : TriggerCommand
    {
        public LayerMask layers;

        void OnTriggerExit(Collider other)
        {
            if (0 != (layers.value & 1 << other.gameObject.layer))
            {
                Send();
            }
        }
    }

}

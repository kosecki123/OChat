using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Orleans;
using GrainInterfaces;

namespace Grains
{
    /// <summary>
    /// Orleans grain implementation class ChatUser.
    /// </summary>
    public class ChatUser : Orleans.Grain, IChatUser
    {
        public Task SendMessage(Guid receiver, string message)
        {
            Console.WriteLine("Sending message \"{0}\" to {1}", message, receiver);

            var receiverGrain = ChatUserFactory.GetGrain(receiver);
            var myself = this.GetPrimaryKey();

            return receiverGrain.ReceiveMessage(myself, message);
        }
        
        public Task ReceiveMessage(Guid sender, string message)
        {
            Console.WriteLine("Message \"{0}\" received from {1}", message, sender);

            return TaskDone.Done;
        }
    }
}

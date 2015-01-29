using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Orleans;

namespace GrainInterfaces
{
    /// <summary>
    /// Orleans grain communication interface IGrain1
    /// </summary>
    public interface IChatUser : Orleans.IGrain
    {
        Task SendMessage(Guid receiver, string message);
        Task ReceiveMessage(Guid sender, string message);
    }
}

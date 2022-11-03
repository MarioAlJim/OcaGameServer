using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcaGameWCF
{
    internal class CallbackService : IChatClient
    {
        private readonly List<string> responses;
        public void RecieveMessage(string message)
        {
            this.responses.Add(message);
        }

        internal CallbackService()
        {
            this.responses = new List<string>();
        }

        internal IList<string> Responses
        {
            get { return this.responses; }
        }
    }
}

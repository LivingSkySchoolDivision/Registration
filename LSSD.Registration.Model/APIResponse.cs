using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class APIResponse
    {
        public bool Success { get; set; }
        public Guid Guid { get; set; }
        public IEnumerable<string> Messages { get; set; } = new List<string>();

        public APIResponse()
        {
            this.Messages = new List<string>();
        }

        public APIResponse(bool Success, IEnumerable<string> Messages)
        {
            this.Success = Success;
            this.Guid = new Guid();
            this.Messages = Messages;

        }

        public APIResponse(bool Success, string Message)
        {
            this.Success = Success;
            this.Guid = new Guid();
            this.Messages = new List<string>() { Message };
        }

        public APIResponse(bool Success, Guid Guid, IEnumerable<string> Messages)
        {
            this.Success = Success;
            this.Guid = Guid;
            this.Messages = Messages;
        }

        public APIResponse(bool Success, Guid Guid, string Message)
        {
            this.Success = Success;
            this.Guid = Guid;
            this.Messages = new List<string>() { Message };
        }

        public APIResponse(bool Success, Guid Guid)
        {
            this.Success = Success;
            this.Guid = Guid;
            this.Messages = new List<string>();
        }

    }
}

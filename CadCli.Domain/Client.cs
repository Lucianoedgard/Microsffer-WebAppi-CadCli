using System;

namespace CadCli.Domain
{
    public class Client
    {
        public Client()
        {
            CreationDate = DateTime.Now;
        }

        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreationDate { get; set; }
        public int ClientTypeId { get; set; }
        public ClientType ClientType { get; set; }
    }
}

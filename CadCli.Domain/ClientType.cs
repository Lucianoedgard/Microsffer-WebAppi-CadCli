using System;

namespace CadCli.Domain
{
    public class ClientType
    {
        public ClientType()
        {
            CreationDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

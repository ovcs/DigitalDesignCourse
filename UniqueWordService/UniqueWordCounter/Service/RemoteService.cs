using RemoteCountLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueWordCounter.Models.Data;
using UniqueWordCounter.Models.Repo;

namespace UniqueWordCounter.Service
{
    internal class RemoteService : IService
    {
        InnerData texts;
        IWordRepoManager rm;
        public RemoteService(InnerData texts, IWordRepoManager rm)
        {
            this.texts = texts;
            this.rm = rm;
        }
        
        public void Run()
        {
            WordCounterClient client = new();
            if (client.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
            {
                var dict = client.GetUniqueCountAsync(texts.StringData).Result;
                rm.Import(dict);
                client.Close();
            }
            else
            {
                throw new Exception("Connection Failt");
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RunningJournalApi
{
    public class JournalController : ApiController
    {
        private static List<JournalEntryModel> entries = new List<JournalEntryModel>();

        public JournalController()
        {
            System.Diagnostics.Trace.WriteLine("JournalController");
        }

        public HttpResponseMessage Get()
        {
            return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, new JournalModel {Entries = entries });
        }

        public HttpResponseMessage Post(JournalEntryModel journalEntry)
        {
            entries.Add(journalEntry);
            return this.Request.CreateResponse();
        }

    }
}

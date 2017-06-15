using Newtonsoft.Json;
using System.Collections.Generic;

namespace RunningJournalApi
{
    public class JournalModel
    {
        public JournalModel()
        {
        }

        [JsonProperty("entries")]
        public List<JournalEntryModel> Entries { get; internal set; }
    }
}
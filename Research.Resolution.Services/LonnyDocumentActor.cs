using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Resolution.Services
{
    public class LonnyDocumentActor : IDocumentActor
    {
        public Document Create()
        {
            return new Document { Name = "Lonny" };
        }

        public void SetName(Document document, string name)
        {
            document.Name = $"Lonny named this one {name}";
        }
    }
}

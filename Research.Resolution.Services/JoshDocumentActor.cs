using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Resolution.Services
{
    public class JoshDocumentActor : IDocumentActor
    {
        public Document Create()
        {
            return new Document { Name = "Josh" };
        }

        public void SetName(Document document, string name)
        {
            document.Name = $"Josh has named this {name}";
        }
    }
}

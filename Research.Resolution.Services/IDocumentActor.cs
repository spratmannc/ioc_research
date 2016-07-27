using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Resolution.Services
{
    public interface IDocumentActor
    {
        Document Create();
        void SetName(Document document, string name);

    }
}

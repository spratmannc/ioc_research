using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Resolution.Services
{
    public class DocumentActorFactory : IDocumentActorFactory
    {
        public IDocumentActor Create(Actor actor)
        {
            switch (actor)
            {
                case Actor.Josh:
                    return new JoshDocumentActor();

                case Actor.Lonny:
                default:
                    return new LonnyDocumentActor();
            }
        }
    }
}

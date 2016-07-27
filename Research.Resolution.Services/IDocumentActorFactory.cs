using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Resolution.Services
{
    public interface IDocumentActorFactory
    {
        IDocumentActor Create(Actor actor);
    }

    public enum Actor
    {
        Josh,
        Lonny,
        Roger,
        Kyle
    }
}

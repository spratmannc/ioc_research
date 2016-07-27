using System;
using Research.Resolution.Services;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Research.Resolution.Comparison
{
    internal class MyDocumentConsumer : IDocumentConsumer
    {
        private Document document;
        private IDocumentActor actor;

        public MyDocumentConsumer(IDocumentActorFactory factory)
        {
            this.actor = factory.Create(Actor.Josh);
            this.document = actor.Create();
        }

        public string GimmeTheName()
        {
            return document.Name;
        }
    }
}